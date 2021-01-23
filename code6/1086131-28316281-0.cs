    public class GridColumns
    {
        private string fName;
        private bool fCheck;
        private DateTime fDate;
        [DisplayName("Checked Option")]
        public bool Checked
        {
            get { return fCheck; }
            set { this.fCheck = value; }
        }
        [DisplayName("File Name")]
        public string fileName
        {
            get { return this.fName; }
            set { this.fName = value; }
        }
        [DisplayName("Date Created")]
        public DateTime createDate
        {
            get { return this.fDate; }
            set { this.fDate = value; }
        }
    }
