    // Get menu when right clicking the Controllers folder in a MVC project.
    var folderCommandBar = (CommandBars)(_applicationObject.CommandBars)["Folder"];
    // Get the Add sub menu.
    var addCommandBarControl = folderCommandBar .Controls["Add"];
    // Cast the control to a command bar popup.
    var addCommandBarPopup  = (CommandBarPopup)addCommandBarControl;
    // Now add the command.
    command.AddControl(addCommandBarPopup, 1);
