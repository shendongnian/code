    //declaration:
    Queue<double> Xholder = new Queue<double>();
    Queue<double> Yholder = new Queue<double>();
    //when new data comes:
    list.Add(x,y);
    Xholder.Enqueue(x);
    Yholder.Enqueue(y);
    
    //when you uncheck then check the checkBox
    for (int i=0; i<Xholder.Count; i++)
    {
      list.Add(Xholder.Dequeue(), Yholder.Dequeue());
    }
 
