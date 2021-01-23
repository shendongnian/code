    public static List<Tuple<string,string,string>> Subs = new List<Tuple<string, string, string>>(); 
    public static void Preload()
    {
            var client = new SoapClient().Admin();
            AutotaskIntegrations ati = new AutotaskIntegrations();
            Field[] fieldInfo = client.GetFieldInfo(ati, "Ticket");
            foreach (var item in fieldInfo)
            {
                if (item.IsPickList)
                {
                    foreach (var pValue in item.PicklistValues)
                    {
                        switch (item.Name)
                        {
                            case "Status":
                                StatusIdByName.Add(pValue.Label, pValue.Value);
                                StatusNameById.Add(pValue.Value, pValue.Label);
                                break;
                            case "IssueType":
                                IssueType.Add(pValue.Label, pValue.Value);
                                break;
                            case "SubIssueType":
                                
                                Subs.Add(new Tuple<string, string, string>(pValue.parentValue, pValue.Label, pValue.Value));
                                break;
                            case "Priority":
                                Priority.Add(pValue.Label, pValue.Value);
                                break;
                            case "Source":
                                Source.Add(pValue.Label, pValue.Value);
                                break;
                            case "ServiceLevelAgreementID":
                                ServiceLevelAgreement.Add(pValue.Label, pValue.Value);
                                break;
                            case "TicketType":
                                TicketType.Add(pValue.Label, pValue.Value);
                                break;
                            case "QueueID":
                                QueueNameById.Add(pValue.Value, pValue.Label);
                                QueueIdByName.Add(pValue.Label, pValue.Value);
                                break;
                            case "AllocationCodeID":
                                AllocationCode.Add(pValue.Label, pValue.Value);
                                break;
                            case "AssignedResourceID":
                                AssignedResource.Add(pValue.Label, pValue.Value);
                                break;
                            case "AssignedResourceRoleID":
                                AssignedResourceRole.Add(pValue.Label, pValue.Value);
                                break;
                        }
                    }
                }
            }
    }
