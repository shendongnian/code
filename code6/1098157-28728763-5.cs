    private void start_button_click(object sender, EventArgs e){
        this.Hide();
        TextBox NBox= (TextBox)Controls.Find("NBox", true)[0];//Retrieve controls by name        
        string name = NBox.Text;
        MessageBox.Show(name);
        //Process.Start("TextGame.exe");
    }
