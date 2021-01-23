    private int clickCount;
    private void btnCoin_Click(object sender, EventArgs e)
    {
        if (++clickCount >= 5)
        {
            // Throw error
            clickCount = 0; // reset click count?
        }
            
    }
