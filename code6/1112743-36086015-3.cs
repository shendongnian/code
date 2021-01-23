    public sealed class Class1CSVMap : CsvClassMap<Class1>
    {
        public Class1CSVMap()
        {
                Map(m => m.Field1).Name("Field1");
                Map(m => m.Field2).Name("Field2");
                Map(m => m.Class2).Name("Field3,Field4").ConvertUsing(row =>  string.Format("{0},{1}", row.Field3, row.Field4); );
                Map(m => m.Class3).Name("Field5,Field6").ConvertUsing(row =>  string.Format("{0},{1}", row.Field5, row.Field6); );
        }
    }
