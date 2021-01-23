    Protected void loadControls()
    {
      DropdownList ddlDynamic = new DropdownList();
      //give this control an id
      ddlDynamic.Id = "ddlDynamic1"; // this  id is very important as the control can be found with same id
      //add data to dropdownlist
      //adding to the panel
      testpanel.Controls.Add(ddlDynamic);
    }
