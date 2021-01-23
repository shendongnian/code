    public class NumberTest
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("".ToInt());
            // 0
            Console.WriteLine("99".ToInt());
            // 99
        }
    }
    public static class StringExtensions
    {
        public static int ToInt(this string text)
        {
            int num = 0;
            int.TryParse(text, out num);
            return num;
        }
    }
    // Use like so with Automapper
    .ForMember(dest => dest.WidgetID, opts => opts.MapFrom(src => src.WidgetID.ToInt()));
