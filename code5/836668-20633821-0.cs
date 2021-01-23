    public class TopicsInfo
    {
        private string pageNo;
    
        public string PAGENO
        {
            get { return pageNo; }
            set { pageNo = value; }
        }
    
        private string selectedTopicString;
        public string SELECTEDTOPICProperty
        {
            get { return selectedTopicString; }
            set
            {
                selectedTopicString = value;
            }
        }
    }
