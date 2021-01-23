    public void Message()
    {
       var obj=GetObject("Irshu");
       var y=  Cast(obj, new { ind= "", flag= true });
       Messagebox.Show(y.ind); //alerts Irshu
    }
    
    public object GetObject(string val){
    
     return new {ind=val,flag=true};
    }
    
    T Cast<T>(object obj, T type)
    {
      return (T)obj;
    }
