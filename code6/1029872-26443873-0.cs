    private void btn_add_Click(object sender, EventArgs e)
            {
    
                clieList.Add(new Client() //This is where the error is
                {
                    Code = Convert.ToInt32(txt_cod.Text),
                    Name = txt_name.Text,
                    Phone = Convert.ToInt32(txt_phone.Text),
                    Email = txt_email.Text,
                });
