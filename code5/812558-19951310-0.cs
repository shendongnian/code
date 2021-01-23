    string ReturnTeamMemberName(object manager, string propName)
    {
       if(manager == null)
          return "None";	  
       return manager.GetType().GetProperty(propName).GetValue(manager, null).ToString();
    }
