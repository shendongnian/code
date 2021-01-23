    public static void DoSomething()
        {
            using (var connection =new SqlConnection("constring"))
            {
                var command = new SqlCommand("myquery", connection);
                connection.Open();
                SqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    var mc = new MyClass();
                    var mydate = rdr["DateFromSQLDB"];
                    if (mydate != null)
                    {
                        DateTime date;
                        if (DateTime.TryParse(mydate.ToString(), out date))
                        {
                            mc.MyDateProperty = date.ToShortDateString();
                        }
                    }
                }
            }
        }
