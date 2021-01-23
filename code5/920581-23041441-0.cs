    public void RollinAlong()
    {
       T t = new T();
       MyFunc(ref t);
       // t has now has the changes here too
    }
    
    public void MyFunc(ref T myobject)
    {
       myobject.make_a_change_outside_method_scope_as_well();
    }
