    public void a0(object sender, System.EventArgs e)
            {
                if (string.IsNullOrEmpty(Convert.ToString(ba0.Content)) || string.IsNullOrWhiteSpace(Convert.ToString(ba0.Content)))
                    ba0.Content = "X";
                else
                    return;
            }
