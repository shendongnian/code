    using (var writer = new CsvWriter(new StreamWriter(@"db.csv", true)))
        {
            writer.WriteRecords(this.Class1List);
            writer.WriteRecords(this.Class2List);
        }
