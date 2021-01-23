        public form1() //Initialize your properties in constructor.
        {
            Texts = new string[10]
        }
        private string[] texts;
        public string[] Texts
        {
            get {return texts; }
            set { texts = value; }
        }
        for(int counter = 0; counter<Texts.Length; counter++)
        {
            Texts[counter]=this.textbox1.Text;
        }
