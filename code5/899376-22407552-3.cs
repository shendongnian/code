    class BookPrices
    {
        private string bookDisplay; //add this private field.
        public string BookDispay    // now create a public property here
        {
            get
            {
              bookDisplay = Name + ", " + price + ", " + Aouther;
              return bookDisplay ;
            }            
        }
