    public new void Enqueue(T obj)
    {
         lock (thisLock)
         {
              base.Enqueue(obj);
         }
    }
    public new T Dequeue()
    {
          lock (thisLock)
          {
               return base.Dequeue();
          }
     } 
