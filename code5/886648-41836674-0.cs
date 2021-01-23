                            using (var client = new WebClient())
                        {
                            try
                            {
                                var webAddr = Properties.Settings.Default.ServerEndpoint;
                                Console.WriteLine("Sending to WebService " + webAddr);
                                //This only applies if the URL access is secured with HTTP authentication
                                if (Properties.Settings.Default.SecuredBy401Challenge)
                                    client.Credentials = new NetworkCredential(Properties.Settings.Default.UserFor401Challenge, Properties.Settings.Default.PasswordFor401Challenge);
                                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                                client.OpenRead(webAddr);
 
                                // Obtain the WebHeaderCollection instance containing the header name/value pair from the response.
                                WebHeaderCollection myWebHeaderCollection = client.ResponseHeaders;
                                Console.WriteLine("\nDisplaying the response headers\n");
                                // Loop through the ResponseHeaders and display the header name/value pairs.
                                for (int i = 0; i < myWebHeaderCollection.Count; i++)
                                    Console.WriteLine("\t" + myWebHeaderCollection.GetKey(i) + " = " + myWebHeaderCollection.Get(i));
                            }
                            catch (Exception exc)
                            {
                               Console.WriteLine( exc.Message);
                            }
                        }
