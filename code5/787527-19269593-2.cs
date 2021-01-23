            using (var sqlConnSource = new SqlConnection(SqlSource))
            {
                sqlConnSource.Open();
                var myProducts = sqlConnSource.Query<Class1>("SELECT * FROM Products").ToList();
                foreach (var p in myProducts)
                {
                    //do something more useful here if you want
                  Console.Writeline("The product name is:" + p.Name)
                }
            }
