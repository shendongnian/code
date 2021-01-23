    using Store.Models;
    namespace Store.Business
    {
        public class InvoiceBL
        {
            public int CalcAge(DateTime? date)
            {
                Age = 25;
                //TODO: Come back and enter proper logic to work out age
                // Something like:
                // return date != null ? <DateTime.Now.Year - date.Year etc.> : null
                return Age;
            }
