       bool result = basketballWcf.Validate(textBoxUser.Text, textBoxPass.Text);
            if (result)
            {
                this.Hide();
                GameChoose gc = new GameChoose();
                gc.Show();
            }
            else
            {
                MessageBox.Show("check please USERNAME or PASSWORD");
                textBoxPass.Text = "";
            }
