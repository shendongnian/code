    foreach (DataRow dr in statusTable.Rows)
    {
        Entity updEntity = new Entity("ABZ_NBA");
        updEntity["ABZ_NBAid"] = query.ToList().Where(a => a.NotificationNumber == dr["QNMUM"].ToString()).FirstOrDefault().TroubleTicketId;
        //updEntity["ABZ_makerfccall"] = false;
        updEntity["ABZ_rfccall"] = null;
    
        updEntity[cNBAttribute.Key] = dr["test"];
        req.Requests.Add(new UpdateRequest() { Target = updEntity });
    
        if (req.Requests.Count == 1000)
        {
            responseWithResults = (ExecuteMultipleResponse)_orgSvc.Execute(req);
            req.Requests = new OrganizationRequestCollection();
        }
    }
    
    if (req.Requests.Count > 0)
    {
        responseWithResults = (ExecuteMultipleResponse)_orgSvc.Execute(req);
    }
