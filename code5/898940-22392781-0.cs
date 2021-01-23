    private void btn_Finish(args...)
    {
        form1.CloseAll();
        form2.CloseAll();
        form3.CloseAll();
        // Only if the main form is closed/Invisible
        MainForm.Show()
        // OR
        MainForm.Visible = true;
    }
