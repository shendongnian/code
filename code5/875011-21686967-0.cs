            int thisUserSecurityLevel = (int)Master.thisUserSecurityLevel;
            int thisUserSelectedException = Convert.ToInt32(Request.QueryString["RTOExceptionId"]);
            using (RTOExceptionDataContext thisDataContext = new RTOExceptionDataContext())
            {
                var query = from tracking in thisDataContext.vw_RTOExceptionWorkflowTransitionMaps
                            where tracking.RTOExceptionId.Equals(thisUserSelectedException) &&
                            tracking.RTOSecurityLevel.Equals(thisUserSecurityLevel)
                            select new { tracking.RTOTransitionCd, tracking.TransitionDisp };
                if (query.Count() > 0)
                {
                    rdoSelectTransition.DataSource = query;
                    rdoSelectTransition.DataTextField = "TransitionDisp";
                    rdoSelectTransition.DataValueField = "RTOTransitionCd";
                    rdoSelectTransition.DataBind();
                }                
            }
        }
