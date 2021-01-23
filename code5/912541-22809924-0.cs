       // create event in class
       public event Action MyEvent;
       // add delegates in constructor
       MyEvent += getA1;
       MyEvent += getAll_LRDe;
       MyEvent += getAll_RL;
       // execute all methods
       if (MyEvent != null)
           MyEvent();
