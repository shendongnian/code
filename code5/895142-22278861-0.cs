        //..
        string[] inputLines = {"your", "input", "goes", "here"}
        //..
        //..
        p.Start();
        using (StreamWriter sw = p.StandardInput)
        {
            if (sw.BaseStream.CanWrite)
                foreach(string line in inputLines) sw.WriteLine(line);
        }
        string output = "+"; 
        string outputErr = "-";
        output = p.StandardOutput.ReadToEnd();
        outputErr = p.StandardError.ReadToEnd();
        p.WaitForExit(); 
