    protected void lbnAdd_Click(object sender, EventArgs e)
    {
        List<ProductPacking> prodVariantDetail = new List<ProductPacking>();
        // get the last product variant IDs from ViewState
        prodVariantIDList = this.SelectedVariantDetailIDs;
        foreach (RepeaterItem ri in Repeater1.Items)
        {
            GridView gvProduct = (GridView)ri.FindControl("gvProduct");
            foreach (GridViewRow gr in gvProduct.Rows)
            {
                CheckBox cb = (CheckBox)gr.FindControl("cbCheckRow");
                if (cb.Checked)
                {
                    // add the corresponding DataKey to idList
                    prodVariantIDList.Add(gvProduct.DataKeys[gr.RowIndex].Value.ToString());
                }
            }
        }
        for (int i = 0; i < prodVariantIDList.Count; i++)
        {
            Label1.Text += prodVariantIDList[i];
            prodVariantDetail.Add(prodPackBLL.getProdVariantDetailByID(prodVariantIDList[i]));
        }
        gvFinalised.DataSource = prodVariantDetail;
        gvFinalised.DataBind();
        // save prodVariantIDList to ViewState
        this.SelectedVariantDetailIDs = prodVariantIDList;
    }
