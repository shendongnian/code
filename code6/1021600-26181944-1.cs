    public void StartGame()
    {
        using(frmNewGame OpenForm = new frmNewGame())
        {
            if(DialogResult.OK == OpenForm.ShowDialog())
            {
               lblName1.Text = OpenForm.Player1;
               lblName2.Text = OpenForm.Player2;
               lblName1.Visible = true;
               lblName2.Visible = true;
               .....
            }
        }
    }
