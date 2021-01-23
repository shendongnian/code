        Dictionary<string, List<int>> data = new Dictionary<string,List<int>>();
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            string name = row.Cells[1].ToString();
            int ID =  Convert.ToInt32(row.Cells[0]);
            if (data.ContainsKey(name)) data[name].Add(ID);
            else data.Add(name, new List<int>(new int[] { ID }));
        }
        foreach (string name in data.Keys)
            if (data[name].Count > 1 ) 
            {
                Console.Write(name);
                foreach (int ID in data[name]) Console.Write(ID.ToString("##### "));
                Console.WriteLine();
            }
