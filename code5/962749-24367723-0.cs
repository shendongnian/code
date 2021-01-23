    SortedDictionary<int, int> sd = new SortedDictionary<int, int>();
    sd.Add(1, 54);
    sd.Add(5, 12);
    sd.Add(3, 17);
    sd.Add(9, 1);
    sd.Add(2, 44);
    MessageBox.Show("First: " + sd[sd.Keys.ElementAt<int>(0)].ToString() + "\nLast: " + sd[sd.Keys.ElementAt<int>(sd.Count-1)].ToString());
