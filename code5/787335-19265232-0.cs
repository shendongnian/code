        bool blink = false
        Color originalColor;
        private void Form1_Load(object sender, EventArgs e)
        {
            originalColor = Button1.BackColor;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            blink = !blink;
            if (blink)
            {
                Button1.BackColor = Color.Aqua;
            }
            else
            {
                Button1.BackColor = originalColor;
            }
        }   
