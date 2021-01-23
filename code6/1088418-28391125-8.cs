        public static string GetString()
        {
            return "xyz";
        }
        public interface IStorage
        {
            Func<object> Get { get; set; }
        }
        public class ManagingModel : IStorage
        {
            public Func<object> Get { get; set; }
        }
