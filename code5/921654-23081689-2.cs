    var foo = new Foo();
    foo.Bar1(); // Creates a transaction named Bars in category Background
    foo.Bar2(); // Same here.
    foo.Bar3(); // Won't create a new transaction.  See notes below.
    
    public class Foo
    {
        // this will result in a transaction with an External Service request segment in the transaction trace
        public void Bar1()
        {
            new WebClient().DownloadString("http://www.google.com/);
        }
    
        // this will result in a transaction that has one segment with a category of "Custom" and a name of "some custom metric name"
        public void Bar2()
        {
            // the segment for Bar3 will contain your SQL query inside of it and possibly an execution plan
            Bar3();
        }
    
        // if Bar3 is called directly, it won't get a transaction made for it.
        // However, if it is called inside of Bar1 or Bar2 then it will show up as a segment containing the SQL query
        private void Bar3()
        {
            using (var connection = new SqlConnection(ConnectionStrings["MsSqlConnection"].ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM table", connection))
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                }
            }
        }
    }
