    if (UserInformation.LowProducts.Any())
    {
        MessageBox.Show("Some products are running low.");
        SystemManager.CheckQuantity(customToolTip1, this, _screen.Right, _screen.Bottom, 5000);
        timeLeft = 15;
        _timer.Start();
    }
