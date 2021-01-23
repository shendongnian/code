            Console.Write( "Enter your customer ID: " );
            string userValue = Console.ReadLine(); // Get this before you even try and make a connection.
            using( SqlConnection con1 = new SqlConnection( conStr ) ) // using is used here because these objects implement IDisposable
            {
                con1.Open(); // Using will take care of closing the connection when it leaves scope.
                using( SqlCommand cmd1 = new SqlCommand( "SELECT * FROM shippingTable WHERE CustomerId = @CustomerId", con1 ) )
                {
                    using( SqlDataReader dr = cmd1.ExecuteReader() )
                    {
                        if( dr.Read() )
                        {
                            Console.WriteLine( dr[ 1 ] + " Your product was shipped: " + dr[ 5 ] );
                        }
                        else
                        {
                            Console.WriteLine( "Nothing was returned for Customer Id '" + userValue + "'" );
                        }
                    }
                }
            }
