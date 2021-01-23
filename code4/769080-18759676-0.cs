    while (!stRead.EndOfStream)
    {
        string test = stRead.ReadLine();
        string correctString = test.Replace("Figure 1", " Figure 1.2");
        //Etc. etc.....
        listBox1.Items.Add(correctString);
    }
 
