    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person 
                {
                    Name = "John",
                    Courses = new List<Course>
                    {
                        new Course { Name = "Trigonometry", ShouldSerialize = true },
                        new Course { Name = "History", ShouldSerialize = true },
                        new Course { Name = "Underwater Basket Weaving", ShouldSerialize = false },
                    }
                },
                new Person
                {
                    Name = "Georgia",
                    Courses = new List<Course>
                    {
                        new Course { Name = "Spanish", ShouldSerialize = true },
                        new Course { Name = "Pole Dancing", ShouldSerialize = false },
                        new Course { Name = "Geography", ShouldSerialize = true },
                    }
                }
            };
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new CourseListConverter());
            settings.Formatting = Formatting.Indented;
            string json = JsonConvert.SerializeObject(people, settings);
            Console.WriteLine(json);
        }
    }
    class CourseListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<Course>));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((List<Course>)value).Where(c => c.ShouldSerialize).ToArray());
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
    }
    public class Course
    {
        public string Name { get; set; }
        [JsonIgnore]
        public bool ShouldSerialize { get; set; }
    }
