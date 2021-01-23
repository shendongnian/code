    [WebMethod]
    public static string getProjectByID(int id)
    {
        using (dbPSREntities4 myEntities = new dbPSREntities4())
        {
            var thisProject = myEntities.tbProjects.Where(x => x.ProjectID == id);
    
            var columns = thisProject.Select(x => new { x.ProjectContactFirstName, x.ProjectContactLastName }).ToList();
    
            JavaScriptSerializer serializer = new JavaScriptSerializer();
    
            var json = serializer.Serialize(columns); 
    
            return json;
        }
    }
