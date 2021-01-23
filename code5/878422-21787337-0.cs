    class Program {    
        static void Main() {
            Console.WriteLine(DateTimeOffset.Now.ToCustomString());
        }
    }
    
    static class DateHelper {
        public static string ToCustomString(this DateTimeOffset time) {
            return time.ToString("yyyy-MM-ddTHH:mm:sszzz");
        }
    }
