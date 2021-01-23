    List<Food> foodList = new List<Food>();
    
    public void addButton_Click(object sender, EventArgs e)
    {
        Food temp = new Food();
      //Get weight value from a textbox
        temp.weight = Convert.ToDouble(weightTextBox.Text);
      //Get name from a provided dropdownlist
        temp.name = DropDownList1.Text;
      //Add to list
        foodList.Add(temp);
      //Check the number of elements in the list
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + foodList.Count + "');", true);
    }
