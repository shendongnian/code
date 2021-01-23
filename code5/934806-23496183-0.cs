    public IEnumerable<SASF> GetLongReportData(string commSubGp)
    {
    	var context = new Entities();
    	var date = Convert.ToDateTime("2014-03-18");
    	var sasf = (from s context.SASF
    		        where a.RDate == date
    				select s);
    	
    	if (!String.IsNullOrEmpty(commSubGp))
    	{
    		switch (commSubGp)
    		{
    			case "F00":
    				sasf = (from s in sasf
    						s.COMM_SGP.CompareTo("F00") <= 0
    						select s);
    				break;
    			
    			case "n10":
    				sasf = (from s in sasf
    						s.COMM_SGP == "n10"
    						select s);
    				break;
    			
    			default:
    				throw new NotImplementedException(String.Format("commSubGp {0} not implemented", commSubGp));
    		}
    	}
    	else
        {
            throw new ArgumentNullException("Parameter commSubGp is null");
        }
    	return sasf.OrderBy(p => p.Conmkt).ThenByDescending(p => p.MKTTITL).ToList();      
    }
