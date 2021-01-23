    protected void lbnAdd_Click(object sender, EventArgs e)
    {
        List<DistributionStandardPackingUnitItems> prodVariantDetail = new List<DistributionStandardPackingUnitItems>();
        int packagesNeeded = prodPackBLL.getPackagesNeededByDistributionID(distributionID);
        // get the last product variant IDs from ViewState
        prodVariantIDList = this.SelectedVariantDetailIDs;
        foreach (RepeaterItem ri in Repeater1.Items)
        {
            GridView gvProduct = (GridView)ri.FindControl("gvProduct");
            foreach (GridViewRow gr in gvProduct.Rows)
            {
                CheckBox cb = (CheckBox)gr.FindControl("cbCheckRow");
                //Prevent gvFinalised to store duplicate products
                if (cb.Checked && !prodVariantIDList.Any(i => i == gvProduct.DataKeys[gr.RowIndex].Value.ToString()))
                {
                    // add the corresponding DataKey to idList
                    prodVariantIDList.Add(gvProduct.DataKeys[gr.RowIndex].Value.ToString());
                }
            }
        }
        for (int i = 0; i < prodVariantIDList.Count; i++)
        {
            prodVariantDetail.Add(packBLL.getProdVariantDetailByID(prodVariantIDList[i]));
        }
        // get the content of tempDistSPUI from ViewState
        itemList = this.tempDistSPUI;
        // add all elements of itemList to prodVariantDetail
        prodVariantDetail.AddRange(itemList);
        gvFinalised.DataSource = prodVariantDetail;
        gvFinalised.DataBind();
        // save prodVariantIDList to ViewState
        this.SelectedVariantDetailIDs = prodVariantIDList;
    }
