            bool a = false;
            String imagefilepath = @fileName;
            ImageData = File.ReadAllBytes(imagefilepath);
            a = Users.InsertUser(this.txt_userid.Text.Trim().ToUpper(),
                           this.txt_mobnum.Text.Trim().ToUpper(),
                           this.txt_name.Text,
                           this.role_cmbox.Text.Trim().ToUpper(),
                           this.box_branch.Text.Trim().ToUpper(),
                           this.txt_designation.Text.Trim().ToUpper(),
                           this.txt_repassword.Text.Trim().ToUpper(),
                           this.Imagedata); //Here you need to pass the byte array not length
            var param = comm.CreateParameter();
            param.ParameterName = "Imagedata";
            param.Value = Imagedata;
            param.SqlDbType = SqlDbType.Image;
            comm.Parameters.Add(param);
