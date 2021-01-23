      public class CsvExport<T> where T : class
        {
            /// <summary>
            /// The objects
            /// </summary>
            public List<T> Objects;
    
            /// <summary>
            /// Initializes a new instance of the <see cref="CsvExport{T}"/> class.
            /// </summary>
            /// <param name="objects">The objects.</param>
            public CsvExport(List<T> objects)
            {
                Objects = objects;
            }
    
            /// <summary>
            /// Exports this instance.
            /// </summary>
            /// <returns></returns>
            public string Export()
            {
                return Export(true);
            }
    
            /// <summary>
            /// Exports the specified include header line.
            /// </summary>
            /// <param name="includeHeaderLine">if set to <c>true</c> [include header line].</param>
            /// <returns></returns>
            public string Export(bool includeHeaderLine)
            {
    
                StringBuilder sb = new StringBuilder();
                //Get properties using reflection.
                IList<PropertyInfo> propertyInfos = typeof(T).GetProperties();
    
                if (includeHeaderLine)
                {
                    //add header line.
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        sb.Append(propertyInfo.Name).Append(",");
                    }
                    sb.Remove(sb.Length - 1, 1).AppendLine();
                }
    
                //add value for each property.
                foreach (T obj in Objects)
                {
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        sb.Append(MakeValueCsvFriendly(propertyInfo.GetValue(obj, null))).Append(",");
                    }
                    sb.Remove(sb.Length - 1, 1).AppendLine();
                }
    
                return sb.ToString();
            }
    
            //export to a file.
            /// <summary>
            /// Exports the automatic file.
            /// </summary>
            /// <param name="path">The path.</param>
            public void ExportToFile(string path)
            {
                File.WriteAllText(path, Export());
            }
    
            //export as binary data.
            /// <summary>
            /// Exports the automatic bytes.
            /// </summary>
            /// <returns></returns>
            public byte[] ExportToBytes()
            {
                return Encoding.UTF8.GetBytes(Export());
            }
    
            //get the csv value for field.
            /// <summary>
            /// Makes the value CSV friendly.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <returns></returns>
            private string MakeValueCsvFriendly(object value)
            {
                if (value == null) return "";
                if (value is Nullable && ((INullable)value).IsNull) return "";
    
                if (value is DateTime)
                {
                    if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
                        return ((DateTime)value).ToString("yyyy-MM-dd");
                    return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
                }
                string output = value.ToString();
    
                if (output.Contains(",") || output.Contains("\""))
                    output = '"' + output.Replace("\"", "\"\"") + '"';
    
                return output;
    
            }
        }
