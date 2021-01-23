    // The using clause ensures the StreamReader is properly disposed after the closing block.
    using (StreamReader sr = File.OpenText(Application.ExecutablePath))
    {
    	stub = sr.ReadToEnd();
    	opt = stub.Split(filesplit).ToArray();
    }
