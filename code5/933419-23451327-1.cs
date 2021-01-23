    class Book
    {
        ...
        public virtual double Price { get { return price; } set { price = value; } } //Property
        protected double price; //Backing Field
        ...
    }
    class TextBook : Book
    {
        ...
        public override double Price
        {
            set
            {
                if (value <= MIN)
                    price = MIN;
                if (value >= MAX)
                    price = MAX;
                else
                    price = value;
            }
        }    
        ...
    }
