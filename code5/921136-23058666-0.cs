    forach( var a in MyClass.event)
    {
      if(a.MyEvent == DateTime.Today)
       {
         a.MyEvent.AddYears(1);
       }
    }
