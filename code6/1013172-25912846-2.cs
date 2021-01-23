    using System.Data;
    using System.Dynamic; // needs assembly references to System.Core & Microsoft.CSharp
    using System.Linq;
    
    public static class DataReaderExtensions
    {
        public static dynamic AsDynamic(this IDataReader reader)
        {
            return new DynamicDataReader(reader);
        }
    
        private sealed class DynamicDataReader : DynamicObject
        {
            public DynamicDataReader(IDataReader reader)
            {
                this.reader = reader;
            }
    
            private readonly IDataReader reader;
 
            // this method gets called for late-bound member (e.g. property) access   
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                int index = reader.GetOrdinal(binder.Name);
                result = index >= 0 ? reader.GetValue(index) : null;
                return index >= 0;
            }
        }
    }
