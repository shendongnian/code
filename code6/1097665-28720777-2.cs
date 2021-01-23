    public interface IRandom
    {   
    }
    public class Random : IRandom
    {     
    }
    public static class RandomExtensions
    {
        public static string NextInt32s(
            this IRandom random, 
            int neededValuesNumber, 
            int minInclusive, 
            int maxExclusive)
        {
        }
    }
