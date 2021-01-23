    public class CsvHelper
    {
        public static string GetCSVString(List<dynamic> inputList)
        {
            var outputList = new List<Dictionary<string, object>>();
            foreach (var item in inputList)
            {
                Dictionary<string, object> outputItem = new Dictionary<string, object>();
                flatten(item, outputItem, "");
                outputList.Add(outputItem);
            }
            List<string> headers = outputList.SelectMany(t => t.Keys).Distinct().ToList();
            string csvString = ";" + string.Join(";", headers.ToArray()) + "\r\n";
            foreach (var item in outputList)
            {
                foreach (string header in headers)
                {
                    if (item.ContainsKey(header) && item[header] != null)
                        csvString = csvString + ";" + item[header].ToString();
                    else
                        csvString = csvString + ";";
                }
                csvString = csvString + "\r\n";
            }
            return csvString;
        }
        private static void flatten(dynamic item, Dictionary<string, object> outputItem, string prefix)
        {
            if (item == null)
                return;
            foreach (PropertyInfo propertyInfo in item.GetType().GetProperties())
            {
                if (!propertyInfo.PropertyType.Name.Contains("AnonymousType"))
                    outputItem.Add(prefix + "__" + propertyInfo.Name, propertyInfo.GetValue(item));
                else
                    flatten(propertyInfo.GetValue(item), outputItem, (prefix.Equals("") ? propertyInfo.Name : prefix + "__" + propertyInfo.Name));
            }
        }
    }
