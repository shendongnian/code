    protected void gridPgim_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            ISession session = HiHibernateUtil.GetCurrentSession();
            CarePlanReview xCpr = (CarePlanReview)Request.RequestContext.HttpContext.Session["xCpr"];
            if (e.CommandName == "Edit")
            {
                GridViewRow row = gridPgim.Rows[Convert.ToInt32(e.CommandArgument)];
                TableCellCollection tbc = row.Cells;
                Object[] objArray = new Object[row.Cells.Count];
                tbc.CopyTo(objArray, 0);
                DataControlFieldCell problemsCf = (DataControlFieldCell)objArray[Convert.ToInt32(Utility.getAppSetting("pgimProblemIndex"))];
                //String txtProb = ((Label)problemsCf.Controls[1]).Text;
                String txtProb = problemsCf.Text;
                DataControlFieldCell goalCf = (DataControlFieldCell)objArray[Convert.ToInt32(Utility.getAppSetting("pgimGoalIndex"))];
                //String txtGoal = ((Label)goalCf.Controls[1]).Text;
                String txtGoal = goalCf.Text;
                DataControlFieldCell interventionCf = (DataControlFieldCell)objArray[Convert.ToInt32(Utility.getAppSetting("pgimInterventionIndex"))];
                //String txtInt = ((Label)interventionCf.Controls[1]).Text;
                String txtInt = interventionCf.Text;
                DataControlFieldCell diagCode = (DataControlFieldCell)objArray[Convert.ToInt32(Utility.getAppSetting("pgimDiagIndex"))];
                String txtdiag = diagCode.Text;
                int cprId = Convert.ToInt32(hdnCprId.Value);
                // now add the PGIM to this Care Plan
                CareNeeds cneeds = new CareNeeds();
                cneeds.Active = 0;
                cneeds.CprId = cprId;
                cneeds.EditUser = xCpr.SessionUser.Username;
                cneeds.GmtOffset = Convert.ToInt32(Utility.getAppSetting("gmtOffset"));
                cneeds.Goal = txtGoal;
                cneeds.Problem = txtProb;
                cneeds.Interventions = txtInt;
                cneeds.Icd1Code = txtdiag;
                cneeds.AddedDate = DateTime.Now;
                using (ITransaction txn = session.BeginTransaction())
                {
                    session.Save(cneeds);
                    txn.Commit();
                }
                careNeedsDataSource.SelectParameters.Clear();
                careNeedsDataSource.SelectParameters.Add("CprId", System.Data.DbType.Int32, Convert.ToString(cprId));
                careNeedsDataSource.Select();
                careNeedsDataSource.DataBind();
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "jsPanel", "clearPanel();", true);
        }
