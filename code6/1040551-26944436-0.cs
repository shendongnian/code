            var v1 = new ODocument { OClassName = "TestVertex" };
            v1.SetField("Name", "First");
            v1.SetField("Bar", 1);
            var v2 = new ODocument { OClassName = "TestVertex" };
            v2.SetField("Name", "Second");
            v2.SetField("Bar", 2);
            var e1 = new ODocument { OClassName = "TestEdge" };
            e1.SetField("Weight", 1.3f);
            // Add records to the transaction
            _database.Transaction.Add(v1);
            _database.Transaction.Add(v2);
            _database.Transaction.Add(e1);
            // link records
            v1.SetField("in_TestEdge", e1.ORID);
            v2.SetField("out_TestEdge", e1.ORID);
            e1.SetField("in", v1.ORID);
            e1.SetField("out", v2.ORID);
            _database.Transaction.Commit();
