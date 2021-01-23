    public interface IMySpecialControl
    {
        string SpecialData { get; set; }
        int UniqueNumber { get; set; }
    }
    
    public static class MySpecialControlExtension
    {
        public static string SpecialUniqueDataNumber(this IMySpecialControl control)
        {
            return control.SpecialData + control.UniqueNumber.ToString();
        }
    }
    public class Special : IMySpecialControl
    {
        public string SpecialData { get; set; }
        public int UniqueNumber { get; set; }
    }
