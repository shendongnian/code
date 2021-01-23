    public string Name  {
       get { return string.Format("{0} {1}", FirstName, LastName); }
             // you're setting Name to value, that's recursive, you should add another variable.
             internal set { Name = value; }
    }
