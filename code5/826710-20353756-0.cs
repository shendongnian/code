        while (!sr.EndOfStream)
        {
            outputFile = destinationFileName + count + baseName + extension;
            FileStream outputFileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
            
            using (StreamWriter sw = new StreamWriter(outputFileStream))
            {
                for (int j = 1; j <= pageSize; j++)
                {
                    var line = sr.ReadLine();
                    sw.WriteLine(li);
                }
            }
            lst.Clear();
            count++;
        }
