    public List<string> UserType
    {
       get
       {
          return Enum.GetNames(typeof(Condition)).ToList();
       }
    }
