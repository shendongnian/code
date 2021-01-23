        public class ModelObj
        {
            public int position { set; get; }
            public bool isChecked
            {
                get { return IsChecked; }
                set { IsChecked = value; }
            }
            public bool IsChecked;
        }
  
