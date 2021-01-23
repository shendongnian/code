        private void defendCalcButton_Click(object sender, EventArgs e) 
        {
            Control[] matches = this.Controls.Find("enemyNameBox" + tabControl1.SelectedIndex.ToString(), true);
            if (matches.Length > 0 && matches[0] is TextBox)
            {
                TextBox tb = (TextBox)matches[0];
                archEnemyNameBox = tb.Text;
            }
        }
