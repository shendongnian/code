        public static void LoginRequestTest()
        {
            try
            {
                var request1 = new Request() { RequestData = new LoginRequestData() { Username = "foo", Password = "bar" } };
                var request2 = new Request() { RequestData = new LogoutRequestData() };
                var request3 = new Request() { RequestData = new SomeUnknownRequestData() };
                var xml1 = request1.GetXml();
                var xml2 = request2.GetXml();
                try
                {
                    var xml3 = request3.GetXml(); // Throws an exception.
                }
                catch (InvalidOperationException ex2)
                {
                    Debug.WriteLine(ex2.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.ToString()); // No assert
            }
        }
