        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var con = new SqlConnection
            {
                ConnectionString = "Data Source=localhost;Initial Catalog=demo;User ID=sa;Password=mypassword;"
            };
            con.Open();
            const string chkadmin = "select COUNT(*) from dbo.Registrations";
            var command = new SqlCommand(chkadmin, con);
            int count = Convert.ToInt32(command.ExecuteScalar());
            if (count == 0)
            {
                var reg = new AdminUser(); //this is the Registration window class
                this.MainWindow = reg;
                reg.Show();
            }
            else
            {
                var win = new Home(); //this is the Home window class
                this.MainWindow = win;
                win.Show();
            }
        }
