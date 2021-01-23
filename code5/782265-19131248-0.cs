    List<int> RemoveList = new List<int>();
    for (int i = 0; i < path.Length; i++)
    {
        lpath.Add(path[i].ToString());
        RemoveList.Add(int.Parse(arr[i]));
    }
    
    //Remove highest index first.
    RemoveList.OrderByDescending(a=>a);
    for (int i = 0; i < RemoveList.Count; i++)
    {
        dataGridView1.Rows.RemoveAt(RemoveList[i]);
    }
