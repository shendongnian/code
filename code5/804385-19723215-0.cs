                SqlCommand sqlcmd = new SqlCommand("select passed_date from table", con);
                var date = sqlcmd.ExecuteScalar();
                DateTime startDate = (DateTime)date;
                DateTime endDate = DateTime.Now;
                TimeSpan span = endDate.Subtract(startDate);
               
                double days = span.TotalDays;
                if (365 < days)
                {
                    ********your logic ************************     
                }
                
