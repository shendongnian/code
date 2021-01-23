        string[] lines = File.ReadAllLines(openDialog.FileName);
        DataGridView dgv = dataGridView1;
        foreach (string line in lines)
        {
            if(line == "NEXTDATA")
            {
                dgv = dataGridView2;
                continue;
            }
            var text = line.Split(',', '\n');
            dgv.Rows.Add(text);
        }
