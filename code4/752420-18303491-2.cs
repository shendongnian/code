    public class MyMultiKeyDictionary : 
        ICollection<KeyValuePair<Tuple<int, int, int, int>, string>>
    {
        private Dictionary<Tuple<int, int, int, int>, string> dict;
        public string this[int w, int x, int y, int z]
        {
            get { return this.dict[Tuple.Create(w, x, y, z)]; }
            set { this.dict[Tuple.Create(w, x, y, z)] = value; }
        }
        // ... implement ICollection
    }
    var scope = new MyMultiKeyDictionary 
    {
        {
            Tuple.Create(1, 1, 1), "test"
        }
    };
    textBox1.Text = scope[0, 1, 1, 1];
   
