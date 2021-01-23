    private void cbtn_CreateNewAuthor_Click(object sender, EventArgs e)
    {
        using (var db = new ProgramContext())
        {
            var txtForename = flp_AddNewThings.Controls.SingleOrDefault(x => x.Tag == "txtForename");
            var txtSurname = flp_AddNewThings.Controls.SingleOrDefault(x => x.Tag == "txtSurname");
            if (txtForename != null && txtSurname != null)
            {
                var author = new Author(txtForename.Text, txtSurname.Text);
                ...
            }
        }
    }
