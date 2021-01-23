    Task.Factory.StartNew(() =>
                {
                    using (var con1 = new SqlConnection
                    {
                        ConnectionString = @"Data Source=" + instanceName1 + ";Integrated Security=SSPI;" +
                     "MultipleActiveResultSets=true;"
                    })
                    {
                        //more code
                        con1.Open();
                        //more code
                    }
                });
