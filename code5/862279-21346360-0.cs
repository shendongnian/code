    private void MainForm_Load(object sender, EventArgs e){
        if(condition == false){
            MessageBox.Show("Condition not met. Program will now close!");
            Environment.Exit(0);// or Application.Exit();
    
        } else {
        new dialog.ShowDialog();
        }
    }
