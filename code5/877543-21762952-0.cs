    public class MyIndexer
    {
        private Dictionary <int,string> testdctnry = new Dictionary<int,string>();
        public string this[int index]
        {
            get 
            {
                if (index > 0)
                    MessageBox.Show("Hey m Zero");
                return testdctnry[index];
            }
            set
            {
                if (index > 1)
                    MessageBox.Show("Setting up");
                testdctnry[index] = value;
            }
        }
    }
