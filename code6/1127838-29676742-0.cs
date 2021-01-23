    namespace System.Web.Mvc
    {
        public static class TableHelperExtensions
        {
            public static string BuildTr(object _obj)
            {
                var properties = _obj.GetType().GetProperties();
                var tr = "<tr>";
    
                foreach(var property in properties) {
                    tr += String.Format("<td>{0}</td>", property.GetValue(_obj));
                }
    
                tr += "</tr>";
    
                return (tr);
            }
    
            public static string BuildTrHeader(object _obj)
            {
                var properties = _obj.GetType().GetProperties();
                var tr = "<tr>";
    
                foreach (var property in properties)
                {
                    tr += String.Format("<th>{0}</th>", property.Name);
                }
    
                tr += "</tr>";
    
                return (tr);
            }
    
            public static HtmlString BuildTable(this HtmlHelper helper, object _obj)
            {
                if(!IsCollection(_obj.GetType())) {
                    throw new InvalidOperationException("BuildTable helper can be called only on collection object");
                }
    
                var tableStart = String.Format(@"<table>
                                <thead>
                                    {0}
                                </thead>
                                <tbody>", BuildTrHeader((_obj as IEnumerable<object>).ElementAt(0)));
    
                var tableBody = String.Empty;
    
                var coll = _obj as IEnumerable<object>;
    
                foreach(var _ in coll){
                    tableBody += BuildTr(_);
                }
    
                var tableEnd = @"
                                </tbody>
                            </table>";;
    
                return new HtmlString(tableStart + tableBody + tableEnd);
            }
    
            static bool IsCollection(Type type)
            {
                return type.GetInterface(typeof(IEnumerable<>).FullName) != null;
            } 
        }
    }
