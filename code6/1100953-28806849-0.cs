    if (chilFrm == null)
    {
        chilFrm = new ChildForm();
        chilFrm.TopLevel = false;
        chilFrm.Parent = this;
        chilFrm.StartUpProsecc("Created New");
        chilFrm.Show();
    }
    else
    {
        chilFrm.StartUpProsecc("Showed the existing.");
        chilFrm.BringToFront();
    }
    
