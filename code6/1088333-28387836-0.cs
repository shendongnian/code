        var db = App.conn;
        try
        {
            using (var pass = db.Prepare("INSERT INTO Passwords (nameWeb, username, password, link) VALUES (?,?,?,?)"))
            {
                pass.Bind(1, usernameWeb);
                pass.Bind(2, userusername);
                pass.Bind(3, userpassword);
                pass.Bind(4, userlink);
                pass.Step();
            }
        }
        catch
        {
        }
