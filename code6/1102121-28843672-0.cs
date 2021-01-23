    public ListViewItem[] LoadItems(string filePath) {
        // not hardcoding the filePath is a good idea
        
        List<ListViewItem> accumulator = new List<ListViewItem>();
        int countit = 0;
        using (StreamReader sr = new StreamReader(filePath)) {
            while (-1 < sr.Peek()) {
                try 
                    string name = sr.ReadLine();
                    string email = sr.ReadLine();
                    var lvi = new ListViewItem(name.Substring(name.IndexOf(":") + 1));
                    lvi.SubItems.Add(email.Substring(email.IndexOf(":") + 1));
                        // instead of adding this item to the list
                        // --> no more this:: listView1.Items.Add(lvi);
                        // just "accumulate" it 
                    accumulator.Add(lvi);
                    countit++;
                }
                catch (Exception) { }
            }
            // no need to manually close the reader
            // sr.Close();
            // the using clause will close it for you
            numberofforums = countit;
        }
        return accumulator.ToArray();
    }
