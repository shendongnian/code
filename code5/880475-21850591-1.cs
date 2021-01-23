    protected void btnDelete_Click(object sender, EventArgs e)
    {
        List<int> lstE = new List<int>();
        foreach (GridViewRow gridViewRow in gvAccountants.Rows)
        {
            if ((gridViewRow.FindControl("cbDelete") as CheckBox).Checked == true)
            {
                string ID = ((Label)gridViewRow.FindControl("labelID")).Text;
                int n = Convert.ToInt32(ID);
                lstE.Add(n);
                this.Accountant = Data.Instance.NHibernateSession.Load<ClassLibSales.Accountant>(n);
                Data.Instance.NHibernateSession.Delete(this.Accountant);
                Data.Instance.NHibernateSession.Flush();
            }
        }
    }
