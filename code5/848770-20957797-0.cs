    [WebMethod]
    public static string getProjectByID(int id)
    {
        var thisProject = myEntities.tbProjects.Where(x => x.tbProject == id).ToList();
    
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        var json = serializer.Serialize(thisProject);
    
        return json;
    }
