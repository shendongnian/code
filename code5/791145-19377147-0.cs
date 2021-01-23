    public IEnumerable ReadFileIterator(String filePath)
            {
                using (StreamReader streamReader = new StreamReader(filePath, Encoding.Default))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        yield return line;
                    }
                    yield break;
                }
            }
    
            public void WriteToFile(String inputFilePath, String outputFilePath)
            {
                using (StreamWriter streamWriter = new StreamWriter(outputFilePath, true, Encoding.Default))
                {
                    foreach (String line in ReadFileIterator(inputFilePath))
                    {
                        String[] subStrings = line.Split('|');
                        streamWriter.WriteLine(subStrings[8]);
                    }
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
