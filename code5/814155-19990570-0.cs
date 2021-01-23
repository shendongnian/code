    using System.IO;
    ..
    ..
    ..
            static void Main(string[] args)
            {
                string[] filePaths = Directory.GetFiles(@"c:\", "*.pdf");
                string result;
                foreach (var file in filePaths)
                {
                    result = Path.GetFileNameWithoutExtension(file);
                    Console.WriteLine("GetFileNameWithoutExtension('{0}') return '{1}'",
                     file, result);
    
                    var sSplitFileName = file.ToUpper().Split('-');
                    var i = 0;
                    foreach (var item in sSplitFileName)
                    {
                        if (i == 3)
                            //it is product id
                        if (i == 7)
                            //it is chip name
    
                       i++;
                    }
                }
            }
