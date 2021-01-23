    // This function receives an object type that can be a view model or an anonymous 
    // object with the properties you want to change. 
    // This is part of a repository for a Contacts object.
     
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
                // If the property is named Id, don't add it in the update. 
                // It can be refactored to look in the annotations for a key 
                // or any part named Id.
                if(ep.Name != "Id")
                    _context.Entry(con).Property(ep.Name).IsModified = true;
            }
        }
        return _context.SaveChanges();
    }
    
    public static object ToType<T>(object obj, T type)
    {
        // Create an instance of T type object
        object tmp = Activator.CreateInstance(Type.GetType(type.ToString()));
    
        // Loop through the properties of the object you want to convert
        foreach (PropertyInfo pi in obj.GetType().GetProperties())
        {
            try
            {
                // Get the value of the property and try to assign it to the property of T type object
                tmp.GetType().GetProperty(pi.Name).SetValue(tmp, pi.GetValue(obj, null), null);
            }
            catch (Exception ex)
            {
                // Logging.Log.Error(ex);
            }
        }
        // Return the T type object:         
        return tmp;
    }
