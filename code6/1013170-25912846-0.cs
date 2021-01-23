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
                if (index >= 0)
                {
                    result = reader.GetValue(index);
                    return true;
                }
                else
                {
                    result = null;
                    return false;
                }
            }
        }
    }
