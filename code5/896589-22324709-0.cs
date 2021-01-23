    public int GetHashCode(MyClass myobj)
    {
         if(myObj == null)
         {
            return base.GetHashCode();
         }
     	 return (myObj.x != null ? myObj.x.GetGashCode() : 0) ^ (myObj.y != null ? myObj.y.GetGashCode() : 0)
    }
