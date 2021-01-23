    [WebMethod]
    public static string getProjectByID(int id)
    {
        using (dbPSREntities4 myEntities = new dbPSREntities4())
        {
            var thisProject = 
                myEntities.tbProjects
                          .Where(p => p.ProjectID == id)
                          .Select(p => new {
                               p.ProjectContactFirstName,
                               p.ProjectContactLastName
                           }).ToList();
    
            JavaScriptSerializer serializer = new JavaScriptSerializer();  
            var json = serializer.Serialize(thisProject);
            return json;
         }
    }
