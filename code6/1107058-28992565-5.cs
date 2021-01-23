    public static class JavaScriptSerializerObjectExtensions
    {
        public static object JsonElementAt(this object obj, int index)
        {
            if (index < 0)
                throw new ArgumentException();
            var array = obj as object[];
            if (array == null || index >= array.Length)
                return null;
            return array[index];
        }
        public static object JsonPropertyAt(this object obj, string name)
        {
            var dict = obj as IDictionary<string, object>;
            if (dict == null)
                return null;
            object value;
            if (!dict.TryGetValue(name, out value))
                return null;
            return value;
        }
        public static bool IsJsonArray(this object obj)
        {
            return obj is object[];
        }
        public static object [] AsJsonArray(this object obj)
        {
            return obj as object[];
        }
        public static bool IsJsonObject(this object obj)
        {
            return obj is IDictionary<string, object>;
        }
        public static IDictionary<string, object> AsJsonObject(this object obj)
        {
            return obj as IDictionary<string, object>;
        }
        public static bool IsJsonNumber(this object obj)
        {
            if (obj == null)
                return false;
            switch (Type.GetTypeCode(obj.GetType()))
            {
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                    return true;
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Single:
                    Debug.WriteLine("Unexpected integer type " + Type.GetTypeCode(obj.GetType()));
                    return true;
                default:
                    return false;
            }
        }
        public static bool IsJsonBoolean(this object obj)
        {
            return obj is bool;
        }
        public static bool IsJsonString(this object obj)
        {
            return obj is string;
        }
        public static bool IsDateTime(this object obj)
        {
            return obj is DateTime;
        }
        [Conditional("DEBUG")]
        public static void DebugWriteJson(this object obj)
        {
            var sb = obj.DumpJson();
            Debug.WriteLine(sb);
        }
        public static string DumpJson(this object obj)
        {
            var sb = obj.DumpJson(new StringBuilder(), 0, false, string.Empty);
            return sb.ToString();
        }
        static StringBuilder DumpJson(this object obj, StringBuilder sb, int level, bool isPropertyValue, string postfix)
        {
            if (obj == null)
                return sb;
            string prefix = new string(' ', 2 * level);
            if (obj is IList<object>)
            {
                var array = (IList<object>)obj;
                if (isPropertyValue)
                    sb.AppendLine();
                sb.AppendLine(prefix + "[");
                for (int i = 0; i < array.Count; i++)
                {
                    array[i].DumpJson(sb, level + 1, false, (i == array.Count - 1 ? string.Empty : ","));
                }
                sb.AppendLine(prefix + "]" + postfix);
            }
            else if (obj is IDictionary<string, object>)
            {
                if (isPropertyValue)
                    sb.AppendLine();
                sb.AppendLine(prefix + "{");
                var dict = ((IDictionary<string, object>)obj).ToList();
                for (int i = 0; i < dict.Count; i++)
                {
                    sb.AppendFormat("{0}  \"{1}\" : ", prefix, dict[i].Key);
                    dict[i].Value.DumpJson(sb, level + 2, true, (i == dict.Count - 1 ? string.Empty : ","));
                }
                sb.AppendLine(prefix + "}" + postfix);
            }
            else if (obj.IsJsonString())
            {
                string initialPrefix = (isPropertyValue ? "" : prefix);
                sb.AppendLine(initialPrefix + '"' + obj.ToString() + '"' + postfix);
            }
            else
            {
                string initialPrefix = (isPropertyValue ? "" : prefix);
                sb.AppendLine(initialPrefix + obj.ToString().ToLower() + postfix);
            }
            return sb;
        }
