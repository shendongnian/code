    if (checkBox15.IsEnabled == false)
    {
    MessageBox.Show("Are you sure you want to check this?", "Prompt",    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    { 
        Updatelist(); 
    } 
    else
    {
        checkBox15.IsEnabled = false;
        return;
    }  
    }`enter code here`
    else  if (checkBox15.IsEnabled == true)
    {
    checkBox15.Checked = false;
    return;
