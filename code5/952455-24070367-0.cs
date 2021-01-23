        protected void SearchButtonClick(object sender, EventArgs e)
        {
            try
            {
                DataSet tProviderData = SelectProviderWithParameter();
                cProviderSearchGridView.DataSource = tProviderData;
                cProviderSearchGridView.Visible = true;
                cProviderSearchGridView.DataBind();
                if (cProviderSearchGridView.Rows.Count == 0)
                {
                    cSearchMessageLabel.Text = "No results found. Please modify your search and try again.";
                    cSearchMessageLabel.Visible = true;
                }
                else
                {
                    cSearchMessageLabel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private DataSet SelectProviderWithParameter()
        {
            DataSet tProviderData = new DataSet();
            string tProviderTextboxContent = tbProvider.Text.Trim();
            string tCityDropDownSelection = cCityDropDownList.SelectedValue.ToString().Trim();
            string tPracticeGroupDropDownSelection = cProviderDropDownList.SelectedValue.ToString().Trim();
            string tSpecialtyDropDownSelection = cSpecialtyDropDownList.SelectedValue.ToString().Trim();
            string tZipTextboxContent = tbZip.Text.Trim();
            string tProviderContractAreaDropDownSelection = cContractAreaDropDownList.SelectedValue.ToString().Trim();
            using (SqlConnection tProviderConnection = new SqlConnection(DatabaseConnectionString))
            {
                using (SqlDataAdapter tProviderAdapter = new SqlDataAdapter())
                {
                    try
                    {
                        tProviderConnection.Open();
                        SqlCommand tProviderSearch = new SqlCommand("dbo.SearchProvider", tProviderConnection);
                        tProviderSearch.CommandType = CommandType.StoredProcedure;
                        tProviderSearch.Parameters.AddWithValue("Provider", tProviderTextboxContent);
                        tProviderSearch.Parameters.AddWithValue("ProviderCity", tCityDropDownSelection);
                        tProviderSearch.Parameters.AddWithValue("ProviderPracticeGroup", tPracticeGroupDropDownSelection);
                        tProviderSearch.Parameters.AddWithValue("ProviderSpecialty", tSpecialtyDropDownSelection);
                        tProviderSearch.Parameters.AddWithValue("ProviderZipCode", tZipTextboxContent);
                        tProviderSearch.Parameters.AddWithValue("ProviderContractArea", tProviderTextboxContent);
                        tProviderAdapter.SelectCommand = tProviderSearch;
                        tProviderAdapter.Fill(tProviderData);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return tProviderData;
        }
