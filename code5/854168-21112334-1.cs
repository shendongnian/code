        private string nm;
        public string passval
        {
            get { return nm; }
            set { 
                nm = value; 
                // This should rather be done somewhere else, not in the setter
                lbl1.Content = "Time " + nm; 
            }
        } 
