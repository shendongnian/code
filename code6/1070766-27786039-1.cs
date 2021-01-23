        private void Enter_Click(object sender, EventArgs e)
        {
            try
            {
                // Search through database through dr[1] (Table 2) for matching string.
                foreach (DataRow dr in dra)
                {
                    if (dr[1].ToString() == Code.Text)
                    {
                        Success = true;
                        break;
                    }
                }
                if (!Success)
                {
                    // Incorrect password.
                    Code.Text = "Incor";
                }
                else
                {
                    this.Close();
                }
            }
            catch
            {
                // Error, most likely with Database.
                Code.Text = "Error";
            }
        }
    }
