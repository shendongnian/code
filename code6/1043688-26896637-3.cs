    `public partial class YourObjectContext
    {
        [EdmFunction("YourModel", "IntParse")]
        public static double IntParse(string val)
        {
            return int.Parse(val);
        }
    }`
     
