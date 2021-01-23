    void Form2Closing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            Form2 f2 = sender as Form2;
            if (!f2.ClosedByUserElement)
                textBox2.Focus();
        }
    }
