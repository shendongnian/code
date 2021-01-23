    public class Project
    {
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Planner { get; set; }
        public DateTime ScheduleStart { get; set; }
        public DateTime ScheduleEnd { get; set; }
        public double EstimatedCost { get; set; }
        public double ActualCost { get; set; }
        public string AssignedTo { get; set; }
        public Project Clone()
        {
            // If your object has inner collections, or
            // references to other objects, you'll have to deep
            // clone them ***manually***!!!
            return (Project)MemberwiseClone();
        }
    }
    public static class SimpleComparer
    {
        // Item1: property name, Item2 current, Item3 original
        public static List<Tuple<string, object, object>> Differences<T>(T current, T original)
        {
            var diffs = new List<Tuple<string, object, object>>();
            MethodInfo areEqualMethod = typeof(SimpleComparer).GetMethod("AreEqual", BindingFlags.Static | BindingFlags.NonPublic);
            foreach (PropertyInfo prop in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                object x = prop.GetValue(current);
                object y = prop.GetValue(original);
                bool areEqual = (bool)areEqualMethod.MakeGenericMethod(prop.PropertyType).Invoke(null, new object[] { x, y });
                if (!areEqual)
                {
                    diffs.Add(Tuple.Create(prop.Name, x, y));
                }
            }
            return diffs;
        }
        private static bool AreEqual<T>(T x, T y)
        {
            return EqualityComparer<T>.Default.Equals(x, y);
        }
    }
