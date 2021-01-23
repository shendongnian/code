    class Program
        {
            static void Main(string[] args)
            {
                string txtDateBorrowed = "3/17/2014";
                string txtReturnDate = "3/18/2014";
                string txtDaysBorrowed = string.Empty;
    
                DateTime tempDateBorrowed = DateTime.ParseExact(txtDateBorrowed, "M/d/yyyy", null);
                DateTime tempReturnDate = DateTime.ParseExact(txtReturnDate, "M/d/yyyy", null);
                TimeSpan span = DateTime.Today - tempDateBorrowed;
                txtDaysBorrowed = span.ToString();
            }
        }
