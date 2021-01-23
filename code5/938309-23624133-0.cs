    foreach (DataRow row in DataTable.Rows) //you can use any enumerable object here
    {
        string s = row.Fields("name").ToString();
        Thread t = new Thread(new ParameterizedThreadStart(SaveName));
        t.IsBackground = true;
        t.start(s);
    }
    public void SaveName(object s)
    {
        //your code to save the value in 's'
    }
