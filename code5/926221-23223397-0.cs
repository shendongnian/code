    private void button_Click(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (button == null)
            return; //Some error/exception
        Panel parentPanel = button.Parent as Panel;
        if (parentPanel == null)
        {
            //Parent container is not panel
        }
        //Otherwise get the panel properties. 
    }
