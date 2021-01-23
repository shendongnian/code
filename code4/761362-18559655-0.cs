    protected void Page_Load(object sender, EventArgs e)
    {
        string[] fname;
        string[] extn;
        Int64 uname = 12121;
        bool b = false;
       b= home.loadFileview(uname, out fname,out extn);
       if (b)
       {
           for (int count = 0; count <fname.Length; count++)
           {
               ListViewItem listItem = new ListViewItem (new[] { fname[count], extn[count]})
               FileListView.Items.Add(listItem);
           }
       }
    }
