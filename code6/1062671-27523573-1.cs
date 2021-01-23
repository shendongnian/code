    public void CallMyMethod()
    {
      //{...  code here`removed...just for initialize object}
      MyObjectArgs args = new MyObjectArgs();
      args.Count = null;
      args.myOby = myObject;
      MyMethod(args);
    }
    
    public static void MyMethod(MyObjectArgs args)
    {
        //{... code removed...}
        IEnumerable<AnAnotherObject> objects = args.myObj.GetAllObjects();//... get objects
        args.Count = (args.Count == null) ? objects.Count() : args.Count;
        MyPopup popup = CreateMypopup();
        popup.Show();
        popup.OnPopupClosed += (o, e) =>//RoutedEventHandler
        {
            if (--args.Count <= 0)
            {
                Finished();//method to finish the reccursive method;
            }
            else
            {
                MyMethod(args);
            }
        };
    }
