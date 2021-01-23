    public class PS1 : PaymentSystemBase
    {
        public override void ProcessPayment()
        {
            using(var conn = new SqlConnection(PaymentSystemBase.ConnectionString))
            {
               using(var cmd = new SqlCommand("...",conn)
               {
                   //Prepare command
                   conn.Open();
                   cmd.ExecuteXXX();
                   //Process results, etc
               }
            }
        }
    }
