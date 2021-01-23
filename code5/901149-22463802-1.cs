    if (dr == DialogResult.Yes)
    {
        if (this.tabControl1.SelectedTab == tabPage2)
        {
            foreach (var ctrl in tabPage2.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox || ctrl is PictureBox || ctrl is RadioButton)
                {
                    ctrl.Text = "";
                }
            }
        }
    }
