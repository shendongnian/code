    public static void addPerm(System.Windows.Forms.Form targetForm)
    {
        foreach (Control C in targetForm.Controls)
        {
            if (C.GetType() == typeof(TextBox))
            {
                tbPermValue = C.Text;
            }
        }
    }
