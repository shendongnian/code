        public class ObjectToBeUsed
    {
        public Person(int num, string title, string owner, string opendate)
        {
            this.Num = num;
            this.Title = title;
            this.Owner = owner;
            this.OpenDate = opendate;
        }
        private int _num;
        public int Num
        {
            get { return _num; }
            set { _num = value; }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _owner;
        public string Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }
        private string _opendate;
        public string OpenDate
        {
            get { return _opendate; }
            set { _opendate = value; }
        }
        
    }
