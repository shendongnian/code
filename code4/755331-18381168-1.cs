    private void bSave_Click(object sender, EventArgs e)
        {
            Information info = new Information();
            info.Value1 = tbTal1.Text;
            info.Value2 = tbTal2.Text;
            info.Result = tbResultat.Text;     
            resultsList.Add(info);                   
        }
