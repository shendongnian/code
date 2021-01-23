    protected void Button1_Click(object sender, EventArgs e)
            {
                DataTable dt = GroupBudgetSetUpBLL.Instance.GetAllGroupBudgetSetUp();
                DataRow myRow = dt.NewRow();
                dt.Rows.InsertAt(myRow, dt.Rows.Count);
                GrdDynamic.DataSource = dt;
                GrdDynamic.DataBind();
            }
 
