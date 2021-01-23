            private void TestConnection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string con_str = "Server=" + Ip.Text + ";Port=" + Port.Text + ";Database=hospital;Uid=" + login.Text + ";Pwd=" + password.Text + ";";
                var task = new Task(() => TryConnect(con_str));
                task.Start();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        void TryConnect(string con_str)
        {
            try
            {
                
                using (MySqlConnection mcon = new MySqlConnection(con_str))
                {
                    mcon.Open();
                    MessageBox.Show("Connection is OK!");
                    mcon.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ErrorCode.ToString() + " " + ex.Message);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
