       //Save Report to Database 
        public void Save(Report report)
        {
    	  using(EFDbContext context=new EFDbContext ())
    	  {
            assignSettingsToEntity(report);
            assignElementsToEntity(report);
            assignChartsToEntity(report);
    
            int found = context.Reports
                .Select(r => r.ReportId)
                .Where(id => id == report.ReportId)
                .SingleOrDefault();
            // Insert Flow
            if (found == 0)
            {
                context.Reports.Add(report);
            }
    		// Update flow
            else
            {
    		    context.Reports.Attach(report);
                context.Entry(report).State = EntityState.Modified; 
            }
            context.SaveChanges(); 
          } 		
        }
