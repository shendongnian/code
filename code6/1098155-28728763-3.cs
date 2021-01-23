    private void start_button_click(object sender, EventArgs e){
        this.Hide();
        TextBox nbox = (TextBox)Controls.Find("NBox", true)[0];//Retrieve controls by name
        if (NBox != null){
            string name = NBox.Text;
            MessageBox.Show(name);
        }    
        //Process.Start("TextGame.exe");
    }
