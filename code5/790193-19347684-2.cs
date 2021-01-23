    //DataTable DataTbt = new DataTable();
    //SqlCommand Command = new SqlCommand();
    //SqlDataAdapter DtaAdapter = new SqlDataAdapter();
    
    protected void ddlInvoiceNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetReturnRecords("Invoice No", ddlInvoiceNumber.SelectedValue);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", String.Format("alert('Error occured : {0}');", ex.Message), true);
        }
        finally
        {
            //DataTbt.Clear();
            //DataTbt.Dispose();
            //DtaAdapter.Dispose();
            //Command.Dispose();
            //Connection.Close();
        }
    }
    
    private void GetReturnRecords(string searchBy, string searchVal)
    {
        DataTable DataTbt = new DataTable();
        SqlDataAdapter DtaAdapter = new SqlDataAdapter();
        try
        {
            SqlCommand Command = new SqlCommand("SP_SearchPurchasesLines", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@SearchBy", searchBy);
            Command.Parameters.AddWithValue("@SearchVal", searchVal);
            using (Connection)
            {
                Connection.Open();
                DtaAdapter.SelectCommand = Command;
                DtaAdapter.Fill(DataTbt);
            }
            if (DataTbt.Rows.Count > 0)
            {
                GridViewPurchaseReturn.DataSource = DataTbt;
                GridViewPurchaseReturn.DataBind();
            }
            else
            {
                GridViewPurchaseReturn.DataSource = DataTbt;
                GridViewPurchaseReturn.DataBind();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", String.Format("alert('Error occured : {0}');", ex.Message), true);
        }
        finally
        {
            //DataTbt.Clear();
            //DataTbt.Dispose();
            //Command.Dispose();
            //Connection.Close();
        }
    }
    
    private void BindReturnGrid()
    {
        try
        {
    
            DataTable DataTbt = new DataTable();
            SqlDataAdapter DtaAdapter = new SqlDataAdapter("SP_SearchPurchasesLines", Connection);
            using (Connection)
            {
                Connection.Open();
                DtaAdapter.Fill(DataTbt);
            }
            if (DataTbt.Rows.Count > 0)
            {
                GridViewPurchaseReturn.DataSource = DataTbt;
                GridViewPurchaseReturn.DataBind();
            }
            else
            {
                GridViewPurchaseReturn.DataSource = null;
                GridViewPurchaseReturn.DataBind();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
        }
        finally
        {
            //DataTbt.Clear();
            //DataTbt.Dispose();
            //DtaAdapter.Dispose();
            //Connection.Close();
        }
    }
