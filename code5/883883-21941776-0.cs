        if (String.IsNullOrEmpty(valueOne.Text) || String.IsNullOrEmpty(EmptyvalueTwo.Text))
        {
            MessageBox.Show("Error: Empty Fields");
        }        
        else
        {
            if (comboBox1.Text.equals("AND"))
            {
                if (valueOne.Text.equals("T") || valueOne.Text.equals("1"))
                {
                    if (valueTwo.Text.equals("T") || valueTwo.Text.equals("1"))
                    {
                        resOne.Text = "T";
                        resOne.BackColor = Color.LawnGreen;
                        resLineOne.BackColor = Color.LawnGreen;
                    }
                    else
                    {
                        resOne.Text = "F";
                        resOne.BackColor = Color.Salmon;
                        resLineOne.BackColor = Color.Salmon;
                    }
                }
                else
                {
                    resOne.Text = "F";
                    resOne.BackColor = Color.Salmon;
                    resLineOne.BackColor = Color.Salmon;
                }   
            }
        }
