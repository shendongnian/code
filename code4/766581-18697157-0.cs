    public static void ShowBox(string message)
    {
        using (FormMessage frm = new FormMessage())
        {
            frm.Message = message;
            frm.ShowDialog();
        }
    }
