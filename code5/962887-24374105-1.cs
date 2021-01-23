        public List<MyDataItem> DataItems 
        {
            get
            {
                List<MyDataItem> items = new List<MyDataItem>(5);
                
                for (int i = 0; i < 5; i++)
                {
                    items.Add(new MyDataItem { abc = abc[i], qrt = qrt[i], xyz = xyz[i] });
                }
                return items;
            }
        }
        
        int[] abc = new int[5] { 1, 2, 3, 4, 5 };
        int[] qrt = new int[5] { 6,7,8,9,10 };
        int[] xyz = new int[5] { 11,12,13,14,15};
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
    public class MyDataItem
    {
        public int abc { get; set; }
        public int qrt { get; set; }
        public int xyz { get; set; }
    }
 
