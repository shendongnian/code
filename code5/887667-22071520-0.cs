      CohortCollection cohortCol = (CohortCollection)Session["cohortCol"];
            foreach(Cohort cohort in cohortCol.ToList())
            {
                if(cohort.Status.Id != int.Parse(ddlFormation.SelectedItem.Value))
                {
                    cohortCol.Remove(cohort);
                }
            }
            this.CohortGrid.DataSource = cohortCol;
            this.CohortGrid.DataBind();
