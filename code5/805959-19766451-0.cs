        if (txtFormula.Text != string.Empty || txtFormulName.Text != string.Empty){
            if (XtraMessageBox.Show("Are you sure that you want to close the screen without saving your work?", 
                                    "Warning?", 
                                    MessageBoxButtons.YesNo, 
                                    MessageBoxIcon.Question) != DialogResult.Yes) {
                e.Cancel = true;
            }
        }
