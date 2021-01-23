    StreamReader sr = new StreamReader(valuePath);
    string line;
    string[] values;
    int n=0;
    
    while(!sr.EndOfStream)
    {
        line = sr.ReadLine();
        values = line.Split(',');
    
        for(int m=0; m<values.Length; m++)
        {
           dataGridView1[m, n].Value = values[m];
        }
        n++;
    }
    sr.Close();
