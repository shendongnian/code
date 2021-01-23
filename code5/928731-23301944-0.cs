    public List<decimal> GetOrgSolution()
    {
        //Need to use USER id. but we have EMPNO in session. 
        var Users = db.CRM_USERS.Where(c => c.ID == SessionCurrentUser.ID || RelOrgPerson.Contains(c.EMPNO.Value)).Select(c => c.ID);
    
        //Get the organization list regarding to HR organization
        var OrgList = db.CRM_SOLUTION_ORG.Where(c => c.USER_ID == SessionCurrentUser.ID || Users.Contains(c.USER_ID.Value)).Select(c => c.ID);
    
        //Get related solutions ID with the OrgList
        List<decimal> SolutionList = db.CRM_SOLUTION_OWNER.Where(p => OrgList.Contains(p.SOLUTION_ORG_ID.Value)).Select(c => (decimal)c.SOLUTION_ID).Distinct().ToList();
    
        return SolutionList;
    }
