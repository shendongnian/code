    public void displayEditButtons()
    {
        buttonPeopleOne.Text = "Save Changes";
        this.buttonPeopleOne.Click -= new System.EventHandler(this.buttonPeopleOneClear_Click);
        this.buttonPeopleOne.Click += new System.EventHandler(this.buttonPeopleOneSave_Click);
            buttonPeopleTwo.Text = "Delete User";
            this.buttonPeopleTwo.Click -= new System.EventHandler(this.buttonPeopleTwoNext_Click);
            this.buttonPeopleTwo.Click += new System.EventHandler(this.buttonPeopleTwoDelete_Click);
            //change other controls to match the function context
            buttonPeopleChangeFunction.Visible = true;
            this.labelPeopleFunctionHeader.Text = "Edit Current User";
        }
        
        public void displayAddButtons()
        {
            buttonPeopleOne.Text = "Clear";
            this.buttonPeopleOne.Click -= new System.EventHandler(this.buttonPeopleOneSave_Click);
            this.buttonPeopleOne.Click += new System.EventHandler(this.buttonPeopleOneClear_Click);
            buttonPeopleTwo.Text = "Add Contact";
            this.buttonPeopleTwo.Click -= new System.EventHandler(this.buttonPeopleTwoDelete_Click);
            this.buttonPeopleTwo.Click += new System.EventHandler(this.buttonPeopleTwoNext_Click);
            //change other controls to match the function context
            buttonPeopleChangeFunction.Visible = false;
            this.labelPeopleFunctionHeader.Text = "Add New User";
