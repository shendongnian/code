      }
        Siman_dbEntities db = new Siman_dbEntities();
        public string UserNameLogedIn;
        private void btnLogin_Click(object sender, EventArgs e)
        {
        var login = from b in db.Tbl_Users.Where(b => b.Username == txtUsername.Text && b.Password == txt_Password.Text)
                        select b;
            if (login.Count()==1)
            {
                this.Hide();
                main frmmain = new main();
                frmmain.Show();
            }
            var query = db.Tbl_Users.Where(c => c.Username == txtUsername.Text).Single();
            UserNameLogedIn = query.Name.ToString();
        }
