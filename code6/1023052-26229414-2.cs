    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        FrmLogin frm = new FrmLogin();
        if (frm.ShowDialog() == DialogResult.OK)
        {
            Application.Run(new Form1());
        }
        else
        {
            Application.Exit();
        }
