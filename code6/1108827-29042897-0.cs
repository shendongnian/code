    public partial DopplerEffect : UserControl 
    {
        private string m_nextFile;
        public string NextFile
        {
            get { return m_nextFile; }
            set 
            { 
               m_nextFile = value; 
               DoSomethingWithNextFile(); // do loading of your image
            }
        }
        public DopplerEffect() { ... }
    }
