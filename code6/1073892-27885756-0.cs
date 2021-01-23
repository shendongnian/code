    public class classA
    {
        internal string FieldName { get; set; }
        internal string FieldValue { get; set; }
        internal bool IncludeInChecksum { get; set; }
        public classA(string fieldName, string fieldValue, bool includeInChecksum)
        {
            this.FieldName = fieldName;
            this.FieldValue = fieldValue;
            this.IncludeInChecksum = includeInChecksum;
        }
        public string ToQueryString()
        {
            return string.Format("{0}={1}",
                this.FieldName,
                this.FieldValue);
        }
        public void Test()
        {
            var list = new List<classA> { 
                new classA("A", "1", true) ,
                new classA("D", "4", true) ,
                new classA("B", "2", false)  ,
                new classA("C", "3", true) 
            };
            var result = list.
                Where(o => o.IncludeInChecksum).
                OrderBy(o => o.FieldName).
                Select(o => o.ToQueryString()).
                ToStringEx("&");
        }
    }
    public static class ExtensionMethods
    {
        public static string ToStringEx<T>(this IEnumerable<T> items, string separetor = ",")
        {
            if (items == null)
            {
                return "null";
            }
            return string.Join(separetor, items.Select(o => o != null ? o.ToString() : "[null]").ToArray());
        }
    }
