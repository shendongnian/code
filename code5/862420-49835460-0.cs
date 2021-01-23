    using (var db = new DBContext())
            {
                AppUser au = new AppUser()
                {
                    AppUserId = (int)txtID.Content,
                    UserName = txtUserName.Text,
                    Password = txtPwd.Password.ToString(),
                db.Entry(au).State= EntityState.Modified;
                db.SaveChanges();
            }
