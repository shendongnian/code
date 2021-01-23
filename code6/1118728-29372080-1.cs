    private int t1;
    public int T1
    {
         get { return t1; }
         set 
         {
             t1 = value;
             Debug.WriteLine(new System.Diagnostics.StackTrace());
         }
    }
