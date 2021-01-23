			LocalReport localReport = (LocalReport)e.Report;
            //Get all the parameters passed from the main report to the target report.  
            //OriginalParametersToDrillthrough actually returns a Generic list of   
            //type ReportParameter.  
			
            IList<ReportParameter> list = localReport.OriginalParametersToDrillthrough;
            DataTable DT = new DataTable();
                    string org = null;
                    string status = null;
                    //Parse through each parameters to fetch the values passed along with them.  
                    foreach (ReportParameter param in list)
                    {
                        if (param.Name == "org")
                            org = param.Values[0].ToString();
                        else if (param.Name == "status")
                            status = param.Values[0].ToString();
                    }
					
			// Request the datatable from ADO.NET for example or any source that will need the parameters
			
			 var dataSet1 = new DataSets.xx.yy();
            
              if (string.IsNullOrEmpty(org) && string.IsNullOrEmpty(status))
                  DT = dataSet1.GetAllData();
              else
                  DT = dataSet1.GetDataByOrgStatus(org, status);
            localReport.DataSources.Add(new ReportDataSource("DSName", DT));
            localReport.Refresh();
