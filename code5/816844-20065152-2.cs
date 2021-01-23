    private void btnDetails_Click(object sender, EventArgs e)
            {               
                try
                {
                    string[] Row = new string[11]; 
                    Row[0] = "";
                    Row[1] = DocNum.Text;
                    Row[2] = counter00;
                    Row[3] = CategoryNo.Text;
                    Row[4] = cmbMeas.Text;
                    Row[5] = cmbSubMeas.Text;
                    Row[6] = txtTarget.Text;
                    Row[7] = txtActual.Text;
                    Row[8] = cmbCARNo.Text;
                    Row[9] = cmbOverStat.Text;
                    Row[10] = cmbOverStat.Text;
    
                    ListViewItem listItem=new ListViewItem(ROW);
                    MMDetailsList.Items.Add(listItem);
     
                }
                catch (Exception) { }
            }
