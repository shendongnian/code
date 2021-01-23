    if (Session["CaseNumber"] != "" || Session["CaseNumber"] != null)
                {
                    casenumber = Session["CaseNumber"].ToString();
                    guid = Session["guid"].ToString();
                    _duration = bal.viewServiceActivity(guid);
                    case1 = bal.viewCaseDetail(casenumber);
                    dt = bal.getRelatedNotes(guid);
                    Session["CaseNumber"] = null; // Set NULL
                    Session["guid"] = null; // Set NULL
    
                }
