    public class Gen<U> : IGen<U> where U : T
    {
        private U u;
        public void Get<T>(ref T value)
        {
            if (value is U)
            {
                value = (T) u;
            }         
            else
                throw new Exception();
        }
    }
