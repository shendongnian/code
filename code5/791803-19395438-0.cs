    public IEnumerable<usp_Project_Team_GetTeam_Result> usp_Project_Team_GetTeam(string strAssociateId)
    {
       using (ProjectEntities Entities = new ProjectEntities())
       {
           return Entities.usp_Project_Team_GetTeam(strAssociateId);
       }
    }
