    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
    
        bool validated = false;
        using(frmLogin fLogin = new frmLogin())
        {
             if(fLogin.ShowDialog() == DialogResult.OK)
                 validated = true;
        }
        if(validated)
            Application.Run(new Main());
        else
            MessageBox.Show("Bye");
    }
