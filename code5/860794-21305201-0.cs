    void MyFormKeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == 13)
            {
                OkButton_Click(null, null);
               // or you can use OkButton.PerformClick();
            }
    }
