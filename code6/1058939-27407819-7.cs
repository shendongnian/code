    public class Active
    {
        public bool IsActive { get; set; } // Cannot have the same name as the class
        public TimeSpan TimeOfDay { get; set; }
    }
    [DataContract]
    class Foo
    {
        [JsonConverter(typeof(ScheduleDictionaryConverter))]
        [DataMember(Name = "values")]
        public Dictionary<DayOfWeek, List<Active>> Schedule { get; set; }
    }
    public class ScheduleDictionaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Dictionary<DayOfWeek, List<Active>>);
        }
        static IEnumerable<KeyValuePair<string, object>> GetDictionaryValues(Active item, DayOfWeek day, int index)
        {
            string key1 = string.Format("schedule[{0}][{1}][{2}]", day, index, "time");
            yield return new KeyValuePair<string, object>(key1, item.TimeOfDay.ToString());
            string key2 = string.Format("schedule[{0}][{1}][{2}]", day, index, "active");
            yield return new KeyValuePair<string, object>(key2, item.IsActive);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            var value = token.ToObject<Dictionary<string, object>>();
            if (value == null)
                return null;
            var dict = new Dictionary<DayOfWeek, List<Active>>();
            foreach (var pair in value)
            {
                var key = pair.Key;
                var keys = key.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                if (keys.Length != 4)
                    continue; // Error
                if (keys[0] != "schedule")
                    continue;
                DayOfWeek day;
                if (!Enum.TryParse(keys[1], out day))
                    continue;
                int index;
                if (!int.TryParse(keys[2], NumberStyles.Any, CultureInfo.InvariantCulture, out index))
                    continue;
                if (keys[3] == "time")
                {
                    if (pair.Value is string)
                    {
                        TimeSpan span;
                        if (TimeSpan.TryParse((string)pair.Value, out span))
                            dict.DemandScheduleItem(day, index).TimeOfDay = span;
                    }
                }
                else if (keys[3] == "active")
                {
                    if (pair.Value is bool)
                        dict.DemandScheduleItem(day, index).IsActive = (bool)pair.Value;
                }
            }
            return dict;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
                return;
            var Schedule = (Dictionary<DayOfWeek, List<Active>>)value;
            var dict =
                Schedule
                .SelectMany(pair => pair.Value.Select((item, i) => new { Item = item, Day = pair.Key, Index = i }))
                .SelectMany(x => GetDictionaryValues(x.Item, x.Day, x.Index))
                .ToDictionary(pair => pair.Key, pair => pair.Value);
            serializer.Serialize(writer, dict);
        }
    }
    public static class ScheduleExtensions
    {
        public static void Resize<T>(this List<T> list, int count)
        {
            if (list == null || count < 0)
                throw new ArgumentException();
            int oldCount = list.Count;
            if (count > oldCount)
            {
                list.Capacity = count;
                for (int i = oldCount; i < count; i++)
                    list.Add(default(T));
            }
            else if (count < oldCount)
            {
                for (int i = oldCount - 1; i >= count; i--)
                    list.RemoveAt(i);
            }
        }
        public static void EnsureCount<T>(this List<T> list, int count)
        {
            if (list == null || count < 0)
                throw new ArgumentException();
            if (count > list.Count)
                list.Resize(count);
        }
        public static Active DemandScheduleItem(this IDictionary<DayOfWeek, List<Active>> schedule, DayOfWeek day, int index)
        {
            List<Active> inner;
            if (!schedule.TryGetValue(day, out inner))
                schedule[day] = inner = new List<Active>();
            inner.EnsureCount(index+1);
            if (inner[index] == null)
                inner[index] = new Active();
            return inner[index];
        }
    }
