    private void grid_Drop(object sender, DragEventArgs eventarg)
     {
         // check data is present returns a bool
     if (eventarg.Data.GetDataPresent("PersistentObject"))
                {
                    var yourdata=eventarg.Data.GetData("PersistentObject")as Model(T) ;
                    if (yourdata!= null)
                    {
                      // add to gird or whatever.  
                         // place the object as you desire
                    }
         
     }   
