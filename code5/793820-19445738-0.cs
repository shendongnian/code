    private void BtnOk_Click(object sender, EventArgs e)
    {
         _Repository.Create(mydata);
    
         DialogResult = DialogResult.Ok;
         Close();
    }
    
    private void btnCancel_Click(object sender, EventArgs e)
    {
         Close();
    }
