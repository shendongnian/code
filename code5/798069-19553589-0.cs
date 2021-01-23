    public override bool Equals(object o)
    {
      EmployeeObject obj = o as EmployeeObject;
      if(obj == null) return false;
    
      // Return true if all the properties match
      return (Id == obj.Id &&
              SubTitle == obj.SubTitle &&
              Desc == obj.Desc &&
              Active == obj.Active &&
              ActiveDateTime == obj.ActiveDateTime);
    }
