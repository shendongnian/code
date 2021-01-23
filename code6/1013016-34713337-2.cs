    //The function receives an object type to receive a custom object can be a view model or an anonymous object wit the properties you will like to change. This is part of a repository for a Contacts object.
     
     public int Update(object entity)
            {
    
                var entityProperties =  entity.GetType().GetProperties();
    
                Contacts con = ToType(entity, typeof(Contacts)) as Contacts;
              
                if (con != null)
                {
                    _context.Entry(con).State = EntityState.Modified;
                    _context.Contacts.Attach(con);
    
                    foreach (var ep in entityProperties)
                    {
    //Here is checking if the property is named Id dont add it in the update. It can be refactored to look in the annotations to find a key or to fin in the name any part named id
                        if(ep.Name != "Id")
                            _context.Entry(con).Property(ep.Name).IsModified = true;
                    }
                }
    
    
                return _context.SaveChanges();
    
            }
    
            public static object ToType<T>( object obj, T type)
            {
                //create instance of T type object:
                object tmp = Activator.CreateInstance(Type.GetType(type.ToString()));
    
                //loop through the properties of the object you want to covert:          
                foreach (PropertyInfo pi in obj.GetType().GetProperties())
                {
                    try
                    {
                        //get the value of property and try to assign it to the property of T type object:
                        tmp.GetType().GetProperty(pi.Name).SetValue(tmp, pi.GetValue(obj, null), null);
                    }
                    catch (Exception ex)
                    {
                      //  Logging.Log.Error(ex);
                    }
                }
                //return the T type object:         
                return tmp;
            }
