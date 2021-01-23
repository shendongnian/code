    private void btnAddScore_Click(object sender, EventArgs e)
        {           
                string name = txtName.Text;
                if(Scores.length <= 3)
                {
                  txtScores.Text = txtScores.Text.ToString() + ", " + txtScore.Text.ToString();
                }
        }
