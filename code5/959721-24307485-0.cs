    ReportPhoneSupportResultTypedView results = new ReportPhoneSupportResultTypedView();
        string[] userIds = model.UserId.Split(',');
        foreach (string userId in userIds)
        {
            int iUserId = 0;
            if (Int32.TryParse(userId, out iUserId))
            {
                RetrievalProcedures.FetchReportPhoneSupportResultTypedView(results, model.FromDate, model.ToDate, iUserId);
            }
        }
        
        //Get the data representing the current grid state - page, sort and filter
        IEnumerable ExcelResults = ((IEnumerable)results).ToDataSourceResult(request).Data;
