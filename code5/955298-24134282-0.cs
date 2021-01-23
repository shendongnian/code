    Object obj = new Object();
    List<int> _list = new List<int>();
    Public void PassList(List<int> myList)
    {
         lock(obj)
         {
             _list = myList;
         }
    }
    
    protected override void OnPaint(PaintEventArgs e)
    {
         lock(obj)
         {
               // Do something with the _list
         }
    }
