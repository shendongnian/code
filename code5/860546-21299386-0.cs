    var isNextDataReached = false;
    foreach (string line in lines)
    {
        if (line == "NEXTDATA")
        {
            isNextDataReached = true;
            continue;
        }
        if (!isNextDataReached)
        {
            var text = line.Split(',', '\n');
            dataGridView1.Rows.Add(text);
        }
        else
        {
            // separate logic to display text in another control
        }
    }
