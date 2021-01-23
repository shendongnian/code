    private void defendCalcButton_Click(object sender, EventArgs e) 
    {
       for (int i = 0; i < tabControl1.SelectedIndex; i++)
       {
           TextBox tb2 = new TextBox();
           tb2 = ((TextBox)(enemyTab.Controls.Find("enemyNameBox" + i, true)[0]));
           archEnemyNameBox = tb2.Text;
       }
    }
