    private void timer1_Tick(object sender, EventArgs e) {
       String textt = textBox1.Text;
       if(MouseButtons != MouseButtons.Left) SendKeys.Send(textt);
    }
    //then you can freely click your button to stop it.
