    Timer t = sender as Timer;
    foreach(var kvp in dictionary){ // Could also do KeyValuePair<int, FrmData> instead of var
        if(kvp.Value.Timer == t)
        {
             int key = kvp.Key
             // Do something with the key
        }
    }
    public struct FrmData
    {
        int num;
        int x;
        Timer t;
        public Timer Timer
        {
            get { return t; }
        }
    }
