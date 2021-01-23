    List<Entity> lstEntity = new List<Entity>();
    if (dt.Rows.Count > 0)
                {
                foreach( Datarow r in dt.Rows){ 
                    Entity e= new Entity();   
                    e.Id = r.Field<int>("Id");
                    e.Username = r.Field<string>("Username");
                    e.Password = r.Field<string>("Password");                   
                    e.UserRole = r.Field<string>("UserRole");
                    lstEntity.Add(e);
                   }
                    return true;
                }
