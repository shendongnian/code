    internal class Program
    {
        public class Entity
        {
            public int Id { get; set; }
        }
        private static void Main(string[] args)
        {
            Expression<Func<Entity, int>> fn = e => e.Id;
            // breakpoint here
        }
    }
