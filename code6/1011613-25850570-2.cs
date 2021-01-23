    class MySimpleLog
    {
        private string _filename;
        private bool _addtime;
        public MySimpleLog(string filename)
        {
            _filename = filename;
        }
        public MySimpleLog(string filename, bool addtime)
        {
            _filename = filename;
            _addtime = addtime;
        }
        
    	public void AppendText(string msg)
    	{
            // Create an instance of StreamWriter to write text to a file.
            // The using statement also closes the StreamWriter.
            using (StreamWriter sw = new StreamWriter(_nomeFile, true))
            {
                // Add some text to the file.
                msg = (_addtime ? DateTime.Now.ToString() + ": " + msg : msg);
                sw.WriteLine(msg);
            }
    	}
    }
