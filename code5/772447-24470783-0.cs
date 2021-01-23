        // for rad 1
        private void rad_NoDifferent_CheckedChanged(object sender, EventArgs e) {
            if(rad_NoDifferent.Checked) {
                rtb_GSC_Notes.AppendText(sRating_NoDiffMsg);
                } else {
                rtb_GSC_Notes.Text = rtb_GSC_Notes.Text.Replace(sRating_NoDiffMsg, sNoMsg.TrimEnd());
                }
            }
        // for rad 2
        private void rad_VeryDifferent_CheckedChanged(object sender, EventArgs e) {
            if(rad_VeryDifferent.Checked) {
                rtb_GSC_Notes.AppendText(sRating_VeryDiffMsg);
                } else {
                rtb_GSC_Notes.Text = rtb_GSC_Notes.Text.Replace(sRating_VeryDiffMsg, sNoMsg.TrimEnd());
                }
            }
        // for rad 3
        private void rad_Unsure_CheckedChanged(object sender, EventArgs e) {
            if(rad_Unsure.Checked) {
                rtb_GSC_Notes.AppendText(sRating_UnsureMsg);
                } else {
                rtb_GSC_Notes.Text = rtb_GSC_Notes.Text.Replace(sRating_UnsureMsg, sNoMsg.TrimEnd());
                }
            }
        // for button reset
        private void btn_ClearRadioButtons_Click(object sender, EventArgs e) {
            rad_NoDifferent.Checked = false;
            rad_Unsure.Checked = false;
            rad_VeryDifferent.Checked = false;
            }
