    private void txtProductCode1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Control && e.KeyCode == Keys.Space)
                {
                    frmProducts cs = new frmProducts();
                    if (cs.ShowDialog() == DialogResult.OK)
                    {
                        //it says you that user didn't cancel child form without selecting item
                        //parent form is frozen until user finishes his selecting on child form
                        //you have to create some public property in child form which you fill after
                        //user clicks on Select then you can do following:
                        this.MyTextbox.Text = cs.SomePropertyIveCreatedToHoldData;
                    }
    
                }
            }
