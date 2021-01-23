    Microsoft.VisualStudio.CommandBars.CommandBar menuBarCommandBar = 
        ((Microsoft.VisualStudio.CommandBars.CommandBars)_applicationObject.CommandBars)["MenuBar"];
    CommandBarPopup myNewPopUpControl = 
        menuBarCommandBar.Controls.Add(MsoControlType.msoControlPopup) as CommandBarPopup;
    myNewPopUpControl.Caption = "MyMenu";
    myNewPopUpControl.Visible = true;
