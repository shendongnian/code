    private void rbOne_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTwo.Checked)
            {
             // make it uncheck  and remove the red rectangle
            } 
            {
            if (rbOne.Checked)
            {
                status = rbOne.Text;
                buff.write(Color.Red, status);
            }
        }
    private void rbTwo_CheckedChanged(object sender, EventArgs e)
    {
        if (rbOne.Checked)
        {
         // make it uncheck  and remove the blue rectangle
        } 
        if (rbTwo.Checked)
        {
            status = rbTwo.Text;
            buff.write(Color.Blue, status);
        }
    } 
