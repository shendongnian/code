    public string Name  {
       get { return string.Format("{0} {1}", FirstName, LastName); }
       internal set 
       {
          var values = value.Split(new char[] { ' ' });
          FirstName = values[0];
          LastName = values[1];
       }
    }
