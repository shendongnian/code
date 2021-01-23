    public class SetSelectedInfo : Singleton<SetSelectedInfo> 
    {        
        public string pdfString;
        private string pdfInstance;
        public string PDF { get { return pdfInstance; } }
	    protected SetSelectedInfo () 
        {
        } 
        void Start()
        {
            UI.SetActive(false);
            pdfInstance = pdfString;
        }
    }
