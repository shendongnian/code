    private bool updating;
    private void A_TextChanged(object sender, EventArgs e)
    {
        if (!updating) {
            updating = true;
            B.Text = f(A.Text);
            updating = false;
        }
    }
    private void B_TextChanged(object sender, EventArgs e)
    {
        if (!updating) {
            updating = true;
            A.Text = f(B.Text);
            updating = false;
        }
    }
