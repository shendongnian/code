    private void button3_Click(object sender, EventArgs e)
    {
        ProjectDBDataContext Context = new ProjectDBDataContext();
        var r =
                from b in Context.TeacherDetails
                where b.TeacherId <= 2
                select b; //Remove .First_Name here
        foreach (TeacherDetail b in r)            
            b.First_Name = "Jerry";
        Context.SubmitChanges();
    }
