    private void bRenameCourse_Click(object sender, EventArgs e)
    {
        if (bRenameCourse.Tag.Equals("Rename"))
        {
            //DO SMTHNG
            bRenameCourse.Tag = "OK";
        }
        else if (bRenameCourse.Tag.Equals("OK"))
        {
            //DO SMTHNG
            bRenameCourse.Tag = "Rename";
        }
    }
