    Control container = new Control();
    LoginView1.RoleGroups[0].ContentTemplate.InstantiateIn(container);
    foreach (Control control in container.Controls)
    {
        if (control.ID == "txtName")
        {
            //Phew. Got your control
        }
    }
