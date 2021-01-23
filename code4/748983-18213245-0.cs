    private void Timer_Tick(object sender, EventArgs e)
    {
        switch (time%5)
            {
                case 0:
                    if (txt1.Text != string.Empty)
                        SendKeys.Send(this.txt1.Text);
                    break;
                case 1:
                    if (txt2.Text != string.Empty) 
                        SendKeys.Send(this.txt2.Text);
                    break;
                
                //finish the switch
            }
            SendKeys.Send("{ENTER}");
            time++;
        }
    }
