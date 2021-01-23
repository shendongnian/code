    //This is our container for our original entity and the calculated field
    public class PersonAndTax<T> 
    {
        public T Entity { get; set; }
        public double Tax { get; set; }
    }
----------
    public class PersonAndTaxHelper
    {
        // This is our middle translation class
        // Each Entity will use a different way to calculate income
        private class PersonAndIncome<T>
        {
            public T Entity { get; set; }
            public int Income { get; set; }
        }
