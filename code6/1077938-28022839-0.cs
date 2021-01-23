    public class Human
    {
        private string h_name = "";
        private string h_gender = "Male";
        private int h_age = 0;
   
        public string Name
        {
            get { return h_name; }
            set { h_name = value; }
        }
    
        public string Gender
        {
            get { return h_name; }
            set { h_name = value; }
        }
        public int Age
        {
            get { return h_age; }
            set { h_age = value; }
        }
        public override string ToString()
        {
            return Name;
        } 
    }
