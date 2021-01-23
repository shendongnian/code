    [TestMethod]
    public void _02_Test_45041_TypeProjectName()
    {
        WpfButton btnAddProj = CommonActions.GetControl<WpfButton>(app, "AddButton");
        WpfEdit txtProjName = CommonActions.GetControl<WpfEdit>(app, "NewProjectTextBox");
        btnAddProj.ClickField();        
        txtProjName.Text = projectName;
    }
