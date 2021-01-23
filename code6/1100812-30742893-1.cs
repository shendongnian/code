    public sealed class MappingClass : CsvClassMap<Inventory>
        {
            public MappingClass()
            {
                AutoMap();
                Map(m => m.ImageURLS).ConvertUsing(r => r.GetField("Images")
                    .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => new Image{ImageURLS = x}).ToList());
            }
    }
