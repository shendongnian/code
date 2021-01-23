      try {
        ...
      }
      catch (FaultException e) {
        PropertyInfo pi = e.GetType().GetProperty("Detail");
    
        if (pi != null) {
          Object rawDetail = pi.GetValue(e); 
          MyCustomEx detail = rawDetail as MyCustomEx;
          if (detail != null) {
            ...
          }
          ...
        }
        ...
      }
