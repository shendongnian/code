    public MainForm()
    {
        private readonly FoodRegister foodForm = new FoodRegister();
    
        private void foodbtn_Click(object sender, EventArgs e)
        {
            foodForm.SetText(Animallst.SelectedItem == null ? "" : Animallst.SelectedItem.ToString());
            foodForm.Show();
        }
    }
