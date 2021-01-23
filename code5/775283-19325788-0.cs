    public class MyClassMap : CsvClassMap<TestRecord>
    {
        public override void CreateMap()
        {
            Map(m => m.Employee).Index(1);
            Map(m => m.Earning).Index(2);
            Map(m => m.Note).Index(3);
        }
    }
