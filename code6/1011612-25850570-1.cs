    class MySimpleLog
    {
        private string _filename;
        public MySimpleLog(string filename)
        {
            _filename = filename;
        }
        
    	public void AppendText(string msg)
    	{
            // Create an instance of StreamWriter to write text to a file.
            // The using statement also closes the StreamWriter.
            using (StreamWriter sw = new StreamWriter(_nomeFile, true))
            {
                // Add some text to the file.
                sw.WriteLine(msg);
            }
    	}
    }
