    public class DataStruct
    {
        public Boolean check;
        public Boolean Check
        {
            get { return check; }
            set
            {
                check = value;
                if (value) { Debug.WriteLine(this.Name); }
            }
        }
        public string Name { get; set; }
        public string Number { get; set; }
    }
