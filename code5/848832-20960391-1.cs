       public string name
       {
           get
              {
                 object obj = ViewState["name"];
                  return (obj == null) ? "" : obj.ToString();
               }
            set
            {
                 ViewState["name"] = value;
             }
        }
