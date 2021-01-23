     private void ReadFunction()
            {
                using (Microsoft.VisualBasic.FileIO.TextFieldParser MyReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(@"C:\temp\myData.csv"))
                {
                    int lineRead = 1;
                    while (!MyReader.EndOfData)
                    {
                        try
                        {
                            string[] fields = ParseHelper(MyReader.ReadLine(), lineRead++);
                            Console.WriteLine(fields.Length.ToString());
                        }
                        catch (Microsoft.VisualBasic.FileIO.MalformedLineException ex)
                        {
                            Console.WriteLine(ex.Message);
    
                        }
                    }
                    Console.ReadKey();
                }
            }
    
            private string[] ParseHelper(String line, int lineRead)
            {
                MemoryStream mem = new MemoryStream(ASCIIEncoding.Default.GetBytes(line));
                Microsoft.VisualBasic.FileIO.TextFieldParser ReaderTemp = new Microsoft.VisualBasic.FileIO.TextFieldParser(mem);
                ReaderTemp.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                ReaderTemp.SetDelimiters(new string[] { "\t", "," });
                ReaderTemp.HasFieldsEnclosedInQuotes = true;
                ReaderTemp.TextFieldType = FieldType.Delimited;
                ReaderTemp.TrimWhiteSpace = true;
                try
                {
                    return ReaderTemp.ReadFields();
                }
                catch (Microsoft.VisualBasic.FileIO.MalformedLineException ex)
                {
                    throw new MalformedLineException(("Line " + lineRead.ToString() + " is not valid and will be skipped: " + ReaderTemp.ErrorLine + "\r\n\r\n" + ex.ToString()));
                }
                
            }
