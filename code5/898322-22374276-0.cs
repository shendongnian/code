     public static string trace;
    ........
    try
    {
        StreamReader sr = new StreamReader(@"C:\Users\niyo\Documents\TESTs\hfkdjhfkhd.text");
    }
    catch (Exception ex)
    {
        string trace = ex.StackTrace;
        MessageBox.Show("Test");
        frmProto frm = new frmProto();
        frm.Show();
        this.Hide();
    }
