    class myClass
    {
        private string skaitlis1;
        public string Skaitlis1
        {
            get { return skaitlis1; }
            set
            {
                int a;
                if (int.TryParse(value, out a))
                {
                    skaitlis1 = value;
                }
                else
                {
                    skaitlis1 = "0";
                }
            }
        }
    }
