    private bool formIsLarge = false;
    private void buttonGrowShrink(object sender, EventArgs e)
    {
        if (formIsLarge)
        {
            this.Size = new Size(160, 245);
            button1.Text = "Grow Form";
        }
        else
        {
            this.Size = new Size(320, 490);
            button1.Text = "Shrink Form";
        }
        formIsLarge = !formIsLarge;
    }
