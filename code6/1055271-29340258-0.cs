    I am not clear about the approach but as it looks like you are using mvc approach or website where you are using CRM service to CRUD crm records.
    So I am putting my points on that basis:
    
    
     1. First of all you have to check whether you are connected to CRM service or Not (I think you are connected to CRM service thats why are are getting those error message on create or update record but anyway you can check like this below) 
    
    public void SaveTimesheetLine(TimesheetViewModel timesheetLineVm)
    {
    	string payrollId = Convert.ToString(Session["payroll"]);
    	Initiate();
    	using (_serviceProxy = CrmConnector.GetOrganizationProxy(serverConfig))
    	{
    		// This statement is required to enable early-bound type support.
    		//_serviceProxy.EnableProxyTypes();
    		_service = (IOrganizationService) _serviceProxy;
    		
    		
    		WhoAmIRequest request = new WhoAmIRequest();
    		WhoAmIResponse response = (WhoAmIResponse)_service.Execute(request);
    		Guid userId= response.UserId;
    		
    		If(userId==null || userId==Guid.Empty)
    			return; // if userid is null or empty then ur crm service is not connected.
        
    
    
     2. SaveTimesheetLine(TimesheetViewModel timesheetLineVm) you are passing timesheetlineVM, this indicates that you you are creating TimeSheetLine for a TimeSheet. I have reviewed you code and found some errors:
    This is of EnntityReference (LookUp) Type and you are passing string value 
    
        timesheetLineEntity["new_payrollreference"] = new EntityReference("entitylogicalname",new Guid(payrollId));
    
    You are not passing the TimeSheet for which this TimeSheetLine will create
    
        timesheetLineEntity["timesheeetid"]=new EntityReference("timesheet",new Guid(timesheetid));
    
    
    3. [FaultException`1: System.NullReferenceException: Microsoft Dynamics CRM has experienced an error.
    This type of error will come on those case when we are passing null value in CRM. Please check all the values in code and look which is null and required.
    
    
    4. I have also looked on the Update Code ,this is wrong because in every case you don't have `timesheetLineVm.TimesheetId.ToString()` this will be null or blank.
    
    
    
        var timesheetLineEntity = new New_timesheetlineitem()
                            {
        
                                // taken from user input 
                                New_startdatetime = timesheetLineVm.TimesheetLineViewModels.StartDate,
                                New_EndDateTime = timesheetLineVm.TimesheetLineViewModels.EndDate,
                                //new_paytypetimesheetlineitemid = Convert.ToString(timesheetLineVm.TimesheetLineViewModels.PayType),
                                //timesheetLineEntity["new_lunchtime"] = 2;
                                New_SubmittedHours = timesheetLineVm.TimesheetLineViewModels.SubmittedHours
        
                                //_timesheetlineId = _service.Create(timesheetLineEntity);
                            };
        
        
                            var timesheetLineItemList = new List<New_timesheetlineitem>();
                            timesheetLineItemList.Add(timesheetLineEntity);
        
                            var retrievedTimesheet = _serviceProxy.Retrieve("new_timesheet", new Guid(timesheetLineVm.TimesheetId.ToString()), new ColumnSet(new string[] {"new_firstname", "new_lastname", "new_name", "new_payrollreference", "new_timesheetdate", "new_timesheetid", "new_slatimesheetid", "new_stream3timesheetid", "new_candidatetimesheetid", "new_accounttimesheetid", "new_billtoid", "new_contracttypetimesheetid", "new_billratetimesheetid", "new_status", "new_timesheet_new_approverid", "new_invoiced"})) as New_timesheet;
    
    you are declaring `var timesheetLineEntity` and using `timesheetLineVm.TimesheetId.ToString()` in the next line. timesheetLineEntity will only contain these three `New_startdatetime,New_EndDateTime,New_SubmittedHours`
    
    
    I think you have to review this and in case you need my help I'll glad to support you.
    
    Please ignore if this is not helpful for you.
