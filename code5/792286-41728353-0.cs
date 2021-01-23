        SortedDictionary<Tuple<int, int>, string> points = new SortedDictionary<Tuple<int, int>, string>();
        string debug1 = "", debug2 = "";
        foreach (ListViewItem item in listView1.Items)
        {
            Tuple<int, int> tp = new Tuple<int,int>(item.Position.Y, item.Position.X);
            points.Add(tp, item.Text);
            debug1 += item.Text;
        }
        foreach (KeyValuePair<Tuple<int, int>, string> kvp in points)
        {
            debug2 += kvp.Value;
        }
        MessageBox.Show(debug1); //orignal order
        MessageBox.Show(debug2); //sort by position
