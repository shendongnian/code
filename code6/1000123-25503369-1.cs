    protected void tmr1_Tick(object sender, EventArgs e)
            {
                lblMessage.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                lblMessage.Visible = true;
                Thread.Sleep(10000);
                lblMessage.Visible = false;
                
            }
