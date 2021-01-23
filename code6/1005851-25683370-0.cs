    static void Main()
    {
         Application.SetCompatibleTextRenderingDefault(false);
         Application.EnableVisualStyles();
         DialogResult result;
         using (var loginForm = new frmLogin())
         {
             result = loginForm.ShowDialog();
         }
         if (result == DialogResult.OK)
         {
             // login was successful
             Application.Run(new Form1());
         }
    }
