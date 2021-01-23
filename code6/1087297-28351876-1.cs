    private void btn_note_Click(object sender, EventArgs e)
        {
            try
            {
                int score = int.Parse(txtb_note.Text);
            if (score >=1 && score <7)
            {
                if (score == 1)
                {
                    lbl_ergebnis.Text = "very good";
                }
                .
                .
                .
                // Keep going to 6 
            }
            else
            {
                lbl_ergebnis.Text = "invalid";
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
