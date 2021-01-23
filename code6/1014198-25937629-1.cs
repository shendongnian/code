	public static string CSharpClassCodeFromCsvFile(string filePath)
	{
		string[] lines = File.ReadAllLines(filePath);
		string[] columnNames = lines.First().Split(',').Select(str => str.Trim()).ToArray();
		string[] data = lines.Skip(1).ToArray();
		string className = Path.GetFileNameWithoutExtension(filePath);
		// use StringBuilder for better performance
		string code = String.Format("public class {0} {{ \n", className);
		for (int columnIndex = 0; columnIndex < columnNames.Length; columnIndex++)
		{
			code += "\t" + GetVariableDeclaration(data, columnIndex, columnNames[columnIndex]) + "\n";
		}
		code += "}\n";
		return code;
	}
	public static string GetVariableDeclaration(string[] data, int columnIndex, string columnName)
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
		string declaration = String.Format("public {0} {1} {{ get; set; }}", typeAsString, columnName);
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
