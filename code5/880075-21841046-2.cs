    public static tbProject getProjectByID(int id)
    {
        using (dbPSREntities11 myEntities = new dbPSREntities11())
        {
            return myEntities.tbProjects.Where(x => x.ProjectID == id).FirstOrDefault();
        }
    }
