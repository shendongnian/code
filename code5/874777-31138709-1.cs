    public sealed class ConMap : CsvClassMap<Contact> {        
            public override void CreateMap() {
                Map(m => m.FirstName).Name("FirstName").TypeConverter<StringNormalizer>();
            }
        }
