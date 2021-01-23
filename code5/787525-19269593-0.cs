            using (var sqlConnSource = new SqlConnection(SqlSource))
            {
                sqlConnSource.Open();
                var myProducts = sqlConnSource.Query<Class1>("SELECT * FROM Products").ToList();
                foreach (var p in myProducts)
                {
                    //do something here if you want
                }
            }
