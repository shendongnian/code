    public class B
    {
        private readonly A item;
        public B(A item)
        {
            if (!(item is I2))
            {
                throw new ArgumentException("...");
            }
            this.item = item;
        }
    }
