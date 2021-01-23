    private void MainForm_Load(object sender, EventArgs e){
        if(condition == false){
            MessageBox.Show("Condition not met. Program will now close!");
            Application.Exit();
        }
        else {
            new dialog.ShowDialog();
        }
    }
