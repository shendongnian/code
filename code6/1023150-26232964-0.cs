    public class Two : ITwo
    {
        public string Test()
        {
            return ((ITwo)this).ParseValue();
        }
    }
