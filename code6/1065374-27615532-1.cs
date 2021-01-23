     string name = "Test";
            Session["name"] = name;
            bool status =  String.ReferenceEquals(name, Session["name"]);
            string name1 = string.Empty;
            name1 =  (string)Session["name"];            
            status = String.ReferenceEquals(name, name1);
            name1 = "test2";
            status = String.ReferenceEquals(name, name1); 
