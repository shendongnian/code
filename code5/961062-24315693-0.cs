     EnumerableRowCollection<DataRow> rowCollection = dataSet.Tables[0].AsEnumerable();
            //Conert to dictionary
            var result = (from row in rowCollection
                select new
                {
                    From = Convert.ToInt32(row.Field<string>(0)),
                    To = Convert.ToInt32(row.Field<string>(1)),
                    Name = row.Field<string>(2)
                }).ToDictionary(s => s.Name);
            var file = new System.IO.StreamWriter("filepath");
            foreach (var data in result)
            {
                //  data.Key is the name in the table
                file.WriteLine(string.Format("{0,-" + (data.Value.To - data.Value.From).ToString() + "}"));
            }
