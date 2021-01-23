    private void button1_MouseEnter(object sender, EventArgs e)
    {
        _colorCounter = 250;
        button1.UseVisualStyleBackColor = false;
        //button1.BackColor = Color.Black;
        timer1.Start();
        button1.ForeColor = Color.White;            
    }
    private void button1_MouseLeave(object sender, EventArgs e)
    {
        timer1.Stop();
        _colorCounter = 250;
        button1.UseVisualStyleBackColor = true;
        button1.ForeColor = Color.Black;
        button1.BackColor = SystemColors.Control;
        
    }
    private int _colorCounter = 250;
    private void timer1_Tick(object sender, EventArgs e)
    {
        _colorCounter -= 25;
        if (_colorCounter == 0)
        {
            timer1.Stop();
            _colorCounter = 250;
        }
        else
        {
            // Build up a color from counter
            button1.BackColor = Color.FromArgb(_colorCounter, _colorCounter, _colorCounter);
        }
        
    }
