    class BookPrices
    {
        private string bookDisplay; //add this private feild.
        public string BookDispay    // now create a public property here
        {
            get
            {
              return Name + ", " + price + ", " + Aouther;
            }
            set
           {
              bookDisplay = value;
           }
        }
