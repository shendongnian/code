    foreach (Control c in e.Page.Controls)
    {
        WizardProperties props = new WizardProperties();
        SearchLookUpEdit slue = new SearchLookUpEdit();
        foreach (var property in props.GetType().GetProperties())
        {
            if (!(c is Label) && property.Name == c.Name)
            {
                 MessageBox.Show("Matchhh!!");
    
                 if (c is SearchLookUpEdit)
                 {
                     slue = (SearchLookUpEdit)c;
                 }
    
                 int type = Convert.ToInt32(slue.EditValue);
    
                 property.SetValue(props,type,null);
             }
         }
     }
