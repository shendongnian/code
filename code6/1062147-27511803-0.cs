    public static class TextFieldParserTest
    {
        public static void Test()
        {
            var csv = @"""DEF,XYZ,GHI"",""FDNFB,dfhjd""";
            using (var stream = new StringReader(csv))
            using (TextFieldParser parser = new TextFieldParser(stream))
            {
                parser.SetDelimiters(new string[] { "," });
                parser.HasFieldsEnclosedInQuotes = true; // Actually already default
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    Debug.WriteLine(fields.Length);
                    foreach (var field in fields)
                        Debug.WriteLine(field); 
                }
            }
        }
    }
