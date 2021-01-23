    public class RealRandomValueGenerator : IRandomValueGenerator
    {
        public int GenerateRandomValue()
        {
            return new System.Random().Next();
        }
    }
