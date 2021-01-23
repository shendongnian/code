    int i = 0;
    public void Detail_Format()
    {
    	i = i + 1;
    	if(i > 9)
    	  {
    	     this.Detail.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.After;
    	     i = 0;
              }
    	else
    	  {
    	     this.Detail.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.None;
              }
    }
