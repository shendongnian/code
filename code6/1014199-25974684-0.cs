    public class CsvToClass
    {
        public static string CSharpClassCodeFromCsvFile(string filePath, string delimiter = ",", 
            string classAttribute = "", string propertyAttribute = "")
        {
            if (string.IsNullOrWhiteSpace(propertyAttribute) == false)
                propertyAttribute += "\n\t";
            if (string.IsNullOrWhiteSpace(propertyAttribute) == false)
                classAttribute += "\n";
            string[] lines = File.ReadAllLines(filePath);
            string[] columnNames = lines.First().Split(',').Select(str => str.Trim()).ToArray();
            string[] data = lines.Skip(1).ToArray();
            string className = Path.GetFileNameWithoutExtension(filePath);
            // use StringBuilder for better performance
            string code = String.Format("{0}public class {1} {{ \n", classAttribute, className);
            for (int columnIndex = 0; columnIndex < columnNames.Length; columnIndex++)
            {
                var columnName = Regex.Replace(columnNames[columnIndex], @"[\s\.]", string.Empty, RegexOptions.IgnoreCase);
                if (string.IsNullOrEmpty(columnName))
                    columnName = "Column" + (columnIndex + 1);
                code += "\t" + GetVariableDeclaration(data, columnIndex, columnName, propertyAttribute) + "\n\n";
            }
            code += "}\n";
            return code;
        }
        public static string GetVariableDeclaration(string[] data, int columnIndex, string columnName, string attribute = null)
        {
            string[] columnValues = data.Select(line => line.Split(',')[columnIndex].Trim()).ToArray();
            string typeAsString;
            if (AllDateTimeValues(columnValues))
            {
                typeAsString = "DateTime";
            }
            else if (AllIntValues(columnValues))
            {
                typeAsString = "int";
            }
            else if (AllDoubleValues(columnValues))
            {
                typeAsString = "double";
            }
            else
            {
                typeAsString = "string";
            }
            string declaration = String.Format("{0}public {1} {2} {{ get; set; }}", attribute, typeAsString, columnName);
            return declaration;
        }
        public static bool AllDoubleValues(string[] values)
        {
            double d;
            return values.All(val => double.TryParse(val, out d));
        }
        public static bool AllIntValues(string[] values)
        {
            int d;
            return values.All(val => int.TryParse(val, out d));
        }
        public static bool AllDateTimeValues(string[] values)
        {
            DateTime d;
            return values.All(val => DateTime.TryParse(val, out d));
        }
        // add other types if you need...
    }
