    public Form1 Firstform;
    public PS3IP(Form1 ParentForm)
    {
         FirstForm=ParentForm;
    } 
    private void PS3IP_Confirm_Click(object sender, EventArgs e)
    {
        //PS3.ConnectTarget(PS3IP_Textbox1.Text); // Update the IP
        Firstform.Home_picturebox1.Show();
        //this.Close();
    }
