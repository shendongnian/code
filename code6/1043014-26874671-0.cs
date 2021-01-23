    using (MemoryStream stream = new MemoryStream())
            {
                using (DataSet dataSet = new DataSet())
                {
                    using (DataTable table = new DataTable("Mytable"))
                    {
                        
                        dataSet.Tables.Add(table);
                        DataColumn column = table.Columns.Add("Foo", Enum.GetUnderlyingType(typeof(Foo)));
                        column.DefaultValue= Foo.Bar;
                       dataSet.WriteXml(stream, XmlWriteMode.WriteSchema);
                    }
                    stream.Seek(0, SeekOrigin.Begin);
                }
                using (DataSet dataSet = new DataSet())
                {
                    dataSet.ReadXml(stream);
                    DataTable table = dataSet.Tables[0];
                    DataColumn column = table.Columns["Foo"];
                    Console.WriteLine(column.DefaultValue.GetType());
                }
