    private void checkBox_Click(object sender, EventArgs e)
    {
       if (checkBox.Checked == false)
       {
         DialogResult result = MessageBox.Show("Confirmation Message", "Confirm", 
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
         if (result == DialogResult.OK)
         {
             checkBox.Checked = true;
         }
       }
       else
       {
         checkBox.Checked = false;
       }
    }
