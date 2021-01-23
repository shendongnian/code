    private void button_Click(object sender, EventArgs e)
    {        
         Button button = (Button)sender;         
         int value = Int32.Parse(button.Name.Substring(6)); // or use button.Tag
         SubMenu1 SubMenu = new SubMenu1(value);
         SubMenu.ShowDialog();
    }
