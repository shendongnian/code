        protected void gvCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "displayCustomer")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                hfCustomerId.Value = Convert.ToString(e.CommandArgument);
                Label lblCName = (Label)row.FindControl("lblCustomerName");
                txtCustomerName.Text = lblCName.Text;
                Label lblAdd1 = (Label)row.FindControl("lblAddressLine1");
                txtAddressline1.Text = lblAdd1.Text;
                Label lblAdd2 = (Label)row.FindControl("lblAddressLine2");
                txtAddressline2.Text = lblAdd2.Text;
                Label lblPhone = (Label)row.FindControl("lblPhone");
                txtPhone.Text = lblPhone.Text;
                Label lblMobile = (Label)row.FindControl("lblMobile");
                txtMobileNumber.Text = lblMobile.Text;
                Label lblCountry = (Label)row.FindControl("lblCountry");
                // -------------------------- changed code --------------------------
                
                ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByText(lblCountry.Text))
                // at this point country should be filled and selected, so we can bind and select appropriate state
                BindStates();
                Label lblState = (Label)row.FindControl("lblState");
                ddlSate.SelectedIndex = ddlSate.Items.IndexOf(ddlSate.Items.FindByText(lblState.Text))
                // at this point states should be filled and selected, so we can bind and select appropriate District
                BindDistricts();
                Label lblDistrict = (Label)row.FindControl("lblDistrict");
                ddlDistrict.SelectedIndex = ddlDistrict.Items.IndexOf(ddlDistrict.Items.FindByText(lblDistrict.Text))
                //---------------------------------------------------------------------
                Label lblCity = (Label)row.FindControl("lblCity");
                txtCity.Text = lblCity.Text; 
            }
        }
