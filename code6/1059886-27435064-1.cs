    public interface IClient
    {
        T Get<T>(Expression<Func<T, bool>> query);
    }
    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class Client
    {
        public T Get<T>(Expression<Func<dynamic, bool>> query)
        {
            var serializer = new ExpressionSerializer(new JsonSerializer());
            var serializedExpression = serializer.SerializeText(query);
            return (T)Server.Retrieve(serializedExpression, typeof(T).FullName);
        }
    }
    public static class Server
    {
        public static dynamic Retrieve(string serializedExpression, string targetType)
        {
            var people = new List<dynamic> 
                {
                    new { Name = "John", Email = "john@stackoverflow.com" },
                    new { Name = "Jane", Email = "jane@stackoverflow.com" }
                };
            // Try creating an object of the type hint passed to the server
            var typeInstance = Activator.CreateInstance(Type.GetType(targetType));
            if (typeInstance.GetType() == typeof(Person))
            {
                var serializer = new ExpressionSerializer(new JsonSerializer());
                var deserializedExpression = (Expression<Func<Person, bool>>)serializer.DeserializeText(serializedExpression);
                var peopleCasted = (IEnumerable<Person>)people.ToNonAnonymousList(typeof(Person));
                return peopleCasted.Where(deserializedExpression.Compile()).SingleOrDefault();
            }
            else
            {
                throw new ArgumentException("Type is unknown");
            }
        }
    }
