    if (flag) return;
    if (checkBox1.Checked == false)
    {
    checkBox2.Checked = false; checkBox3.Checked = false;
    checkBox4.Checked = false; checkBox5.Checked = false;
    checkBox6.Checked = false; checkBox7.Checked = false;
    checkBox8.Checked = false;//Disable preceeding checkboxes
    enableAllAssessmentsToolStripMenuItem.Checked = false;
    }
    if (checkBox1.Checked == true)
    {
    //Check if checkbox has been checked 
    textBox1.Enabled = true; textBox2.Enabled = true;//Enable that Line's Textboxes
    }
    else
    {
        //Or not
        textBox1.Enabled = false; textBox2.Enabled = false;//Disable that Line's Textboxes
    }
    if(textBox1.Text.Length != 0 || textBox2.Text.Length != 0)
    {
    //If associated textboxes contain text
    DialogResult  Result1 = MessageBox.Show("The numbers you have input on this row will be lost", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
    if (Result1 == DialogResult.OK)
    {
        textBox1.Text = "";
        textBox2.Text = "";
    }
    else if (Result1 == DialogResult.Cancel)
    {
        flag = true;
        checkBox1.Checked = true;
        flag = false;
    }
}
