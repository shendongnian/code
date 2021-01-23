    class Program
    {
        static void Main(string[] args)
        {
            var cSharpClass = CsvToClass.CSharpClassCodeFromCsvFile(@"YourFilePath.csv", ",", "[DelimitedRecord(\",\")]", "[FieldOptional()]");
            File.WriteAllText(@"OutPutPath.cs", cSharpClass);
        }
    }
