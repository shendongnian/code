    public sealed class DataMapper : CsvClassMap<DataType>
    {
        public DataMapper()
        {
            Map(m => m.Field1).Name("FirstField");
            Map(m => m.Field2).Name("SecondField");
            Map(m => m.Field3).ConvertUsing(row =>
            {
                if(string.IsNullOrEmpty(row.Get<string>("ThirdField"))
                    throw new Exception("Oops, ThirdField is empty!");
                return row.Get<string>("ThirdField");
            })
        }
    }
