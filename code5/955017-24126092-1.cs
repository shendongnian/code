            // Create two DataTable instances.
            DataTable table1 = new DataTable("Subscriber");
            table1.Columns.Add("id");
            table1.Columns.Add("Email");
            table1.Rows.Add(1, "email@email.com");
            DataTable table2 = new DataTable("CustomFields");
            table2.Columns.Add("id");
            table2.Rows.Add(1);
            DataTable table3 = new DataTable("CustomField");
            table3.Columns.Add("id");
            table3.Columns.Add("FieldName");
            table3.Columns.Add("Value");
            table3.Rows.Add(1, "FirstName", "FNAME");
            table3.Rows.Add(1, "FirstName", "FNAME");
            table3.Rows.Add(1, "FirstName", "FNAME");
            table3.Rows.Add(1, "FirstName", "FNAME");
            table3.Rows.Add(1, "FirstName", "FNAME");
            table3.Rows.Add(1, "FirstName", "FNAME");
            table3.Rows.Add(1, "FirstName", "FNAME");
            // Create a DataSet and put both tables in it.
            DataSet set = new DataSet("Subscribers");
            set.Tables.Add(table1);
            set.Tables.Add(table2);
            set.Tables.Add(table3);
            set = SetRelationship(set);
            // Visualize DataSet.
            Console.WriteLine(set.GetXml());
            Console.ReadKey();
        }
        private static DataSet SetRelationship(DataSet ds)
        {
            DataRelation relation1 = ds.Relations.Add("Subscriber1", ds.Tables[0].Columns["id"], ds.Tables[1].Columns["id"]);
            DataRelation relation2 = ds.Relations.Add("Subscriber2", ds.Tables[1].Columns["id"], ds.Tables[2].Columns["id"]);
            relation1.Nested = true;
            relation2.Nested = true;
            return ds;
        }
    }
