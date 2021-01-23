    public Reader mr_obj;
    private static readonly object sync = new object();
    public Form1()
    {
        mr_obj = new MyReader.Reader(7137);
        mr_obj.UserEvent += new ReaderEvent(UserEvent);
    }
    
    private void UserEvent(UserEvent e, long threadID)
    {
       lock(sync)
       {
          SafeSomethingToDB();
       }
    }
