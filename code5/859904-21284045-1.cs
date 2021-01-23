    protected void lbnAdd_Click(object sender, EventArgs e)
    {
        List<ProductPacking> prodVariantDetail = new List<ProductPacking>();
        foreach (RepeaterItem ri in Repeater1.Items)
        {
            GridView gvProduct = (GridView)ri.FindControl("gvProduct");
            foreach (GridViewRow gr in gvProduct.Rows)
            {
                CheckBox cb = (CheckBox)gr.FindControl("cbCheckRow");
                if (cb.Checked)
                {
                    // add the corresponding DataKey to idList
                    this.SelectedVariantDetailIDs.Add(gvProduct.DataKeys[gr.RowIndex].Value.ToString());
                }
            }
        }
        for (int i = 0; i < prodVariantIDList.Count; i++)
        {
            Label1.Text += this.SelectedVariantDetailIDs[i];
            prodVariantDetail.Add(prodPackBLL.getProdVariantDetailByID(this.SelectedVariantDetailIDs[i]));
        }
        gvFinalised.DataSource = prodVariantDetail;
        gvFinalised.DataBind();
    }
