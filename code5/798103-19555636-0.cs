    NewUser newuser = new NewUser {
                      Name = Name,
                      ContactNo = Contact,
                      Email = Email,
                      Password = Password,
                      Admin = Admin,
                      ImageURL = ImageURL};
        entdb.CreateUser(newuser.Name, newuser.ContactNo, newuser.Email, newuser.Password, newuser.Admin, newuser.ImageURL);
