    public sealed class MappingClass : CsvClassMap<Inventory>
        {
            public MappingClass()
            {
                AutoMap();
                Map(m => m.Images).ConvertUsing(r => r.GetField("Images").Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList());
            }
    }
