    private string deparmentName;
    public string DepartmentName
    { 
       get { return deparmentName; }
       set 
       {
           deparmentName = value;
           switch(deparmentName)
           {
              case "IT" : StatusID = 1; break;
              case "HR" : StatusID = 2; break;
              default: 
                  StatusID = 0; break;
           }
       }
    }
