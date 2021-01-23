    public class StandardRepository
    {
        MyContext _context;
        
        public StandardRepository(MyContext context)
        {
        	_context = context;
        }
        
        public List<Standard> FindByAgencyID(int agencyID)
        {
            return _context.Standards.Where(r => r.AgencyID == agencyID).ToList();
        }
    }
    
    public class RequirementRepository
    {
        MyContext _context;
        
        public RequirementRepository(MyContext context)
        {
        	_context = context;
        }
        
        public Requirement Save(Requirement requirement)
        {
    	Requirement retVal = requirement;
    	if (requirement.ID.Equals(0))
    	{
    	    retVal = _context.Requirements.Add(requirement);
    	}
    	else
    	{
    	    _context.Entry(requirement).State = EntityState.Modified;
    	}
    
    	_context.SaveChanges();
    	return retVal;
        }
    }
    public class RequirementRepository
    {
        public static string CreateMockData()
        {
        	using(MyContext context = new MyContext())
        	{
                    StandardRepository stdRep = new StandardRepository(context);
                    ProjectRepository projRep = new ProjectRepository(context);
                    RequirementRepository reqRep = new RequirementRepository(context);
                    Project project = projRep.Find(1);
                    StringBuilder sb = new StringBuilder()
                    foreach (Standard s in stdRep.FindByAgencyID(project.Agency.ID))
                    {
    		        Requirement r = new Requirement();
    		        r.Project = project;
    		        r.Standard = s;
    		        r.DateCompleted = (DateTime)SqlDateTime.MaxValue;
    		        r.DateDue = DateTime.Now.AddDays(90);
    
    		        r = reqRep.Save(r);
    
    		        sb.AppendLine(String.Format("Saved Requirement ID {0} with Project ID {1}<br>", r.ID, r.Project.ID));
    		    }
    	    }
            return sb.ToString();
        }
    }
