    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        try
        {
            // Simulating an exception
            throw new Exception("You can't delete this client because it's used!");
        }
        catch (Exception ex)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "alert" + UniqueID,
                "alert(\"" + ex.Message + "\");", true);
    
            // You need to use ScriptManager if you use ajax.
            /*ScriptManager.RegisterStartupScript(this, this.GetType(), "alert" + UniqueID,
    "alert(\"" + ex.Message + "\");", true);*/
        }
    }
