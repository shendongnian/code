        int i = 12345;
        var box = new NumBox (i);
        
        var parent = new Container();
        parent.Add( box );
        
        var j = parent.Elements.FindIndex ( box ); 
        // FindIndex is a built-in IENumerable method like Find() or others that you can see in Intellisense
        
        if (j > = 0)
        {
          parent.Elements[j].Reset();
        }
        var box1 = new NumBox(987654);
        
        parent.UpdateElement(j, box1);
        parent.DeleteAllElements();
