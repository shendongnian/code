    private FoodRegister foodReg { get; set; }
    
    public MainForm(FoodRegister reg)
    {
       foodReg = reg;
    }
    
    private Animallst_onSelectionChanged(object sender, EventArgs args)
    {
       foodReg.Nametxt.Text = (sender as ListBox).SelectedItem.ToString();
    }
