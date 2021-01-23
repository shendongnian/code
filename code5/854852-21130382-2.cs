        protected void typeselect_SelectedIndexChanged(object sender, EventArgs e)
        {
           try{
            seconddropdown.Items.Clear();
            IList<InfoContainer> info = getInfoBasedOnSelected(typeselect.Value);
            seconddropdown.DataTextField = "name";
            seconddropdown.DataValueField = "value";
            seconddropdown.DataSource = info;
            seconddropdown.DataBind();
            }catch(Exception ex)
            {
              throw new ApplicationException("ERROR :", ex);
            }
       }
