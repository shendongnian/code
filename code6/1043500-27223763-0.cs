    [TestMethod]
    public void _01_Test_45040_AddProjectButtonClick()
    {
        //ai.LeftPanelProjects.AddProjectButton.Click();
        WpfButton btnAddProj = CommonActions.GetControl<WpfButton>(app, "AddButton");
        btnAddProj.ClickField();
          
         //calling the second method
        _02_Test_45041_TypeProjectName();
    }
    
    [TestMethod]
    public void _02_Test_45041_TypeProjectName()
    {
        WpfEdit txtProjName = CommonActions.GetControl<WpfEdit>(app, "NewProjectTextBox");
        txtProjName.Text = projectName;
    }
