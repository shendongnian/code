    using (var outputFile = File.CreateText("OutputFile.txt"))
    {
        using (var input1 = File.OpenText("TryAgain.txt"))
        using (var input2 = File.OpenText("File2.txt"))
        {
            while (!input1.EndOfStream  && !input2.EndOfStream))
            {
                int i;
                for (i = 0; i < 4 && !input1.EndOfStream; ++i))
                {
                    var s1 = input1.ReadLine();
                    outputFile.WriteLine(s1);
                }
                if (i != 4) break; // end of first file
                // now read one line from the other file, and output it
                var s2 = input2.ReadLine();
                outputFile.WriteLine(s2);
            }
        }
    }
