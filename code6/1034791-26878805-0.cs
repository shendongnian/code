     if (!Page.IsPostBack)
     {
                List<ClassA> classA = new List<ClassA> { 
                new ClassA { ID = 1, Name = "Name1" } ,
                new ClassA { ID = 2, Name = "Name2" } ,
                new ClassA { ID = 3, Name = "Name3" } ,
                new ClassA { ID = 4, Name = "Name3" } ,
                new ClassA { ID = 5, Name = "Name3" } ,
                new ClassA { ID = 6, Name = "Name3" } ,
                new ClassA { ID = 7, Name = "Name3" } ,
                new ClassA { ID = 8, Name = "Name3" } ,
                new ClassA { ID = 9, Name = "Name3" } 
            };
                var results = from o in classA
                                  //join x in classB on o.ID equals x.ID
                                  select new { o };
                gv_lect.DataSource = results;
                gv_lect.DataBind();
      }
 
