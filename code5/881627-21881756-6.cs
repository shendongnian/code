    private Control FindControlByTag(ControlCollection controls, string tag)
    {
        Control result = null;
        foreach (var ctrl in controls)
        {
            if (ctrl.Tag == tag)
            {
                result = ctrl;
                break;
            }
        }
        return result;
    }
    private void cbtn_CreateNewAuthor_Click(object sender, EventArgs e)
    {
        using (var db = new ProgramContext())
        {
            var txtForename = FindControlByTag(flp_AddNewThings.Controls, "txtForename");
            var txtSurname = FindControlByTag(flp_AddNewThings.Controls, "txtSurname");
            if (txtForename != null && txtSurname != null)
            {
                var author = new Author(txtForename.Text, txtSurname.Text);
                ...
            }
        }
    }
