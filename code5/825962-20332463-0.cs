                TextFieldParser parser = new TextFieldParser(@"D:\test.csv");
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        string test =field;
                    }
                }
                parser.Close();
