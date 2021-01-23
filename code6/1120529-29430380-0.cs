    private void ListBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
       // Get the currently selected item in the ListBox. 
       string curItem = listBox1.SelectedItem.ToString();
    
       switch(curItem)
       {
           case "Person1":
               TextBoxPersons.Text = "Andersson";
           break;
           case "Person2":
               TextBoxPersons.Text = "Smith";
           break;
           //Add more cases and perhaps a default...
       }
    }
