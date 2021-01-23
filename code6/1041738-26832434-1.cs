        private void btnAddScore_Click(object sender, EventArgs e)
        {           
                string scores = txtName.Text;
                if(!string.IsNullOrEmpty(scores) && scores.Split(',').Count() == 3)
                {
                  MessageBox.Show("You can't enter more than three scores");
                  return;
                }
                if (string.IsNullOrEmpty(scores))
                {
                    scores += txtScore.Text;
                }
                else
                {
                    scores += ", " + txtScore.Text;
                }
                txtName.Text = scores;
                              
        }
