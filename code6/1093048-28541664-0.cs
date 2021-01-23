    private async void btnSetVal_Click_1(object sender, RoutedEventArgs e)
    {
        // TODO: Use a loop instead of this repeated code...
        int l_iMilSecs = 1000;
        VolumeMeter.fSetVal(20);
        await Task.Delay(l_iMilSecs);
        VolumeMeter.Value = 30;
        await Task.Delay(l_iMilSecs);
        VolumeMeter.Value = 40;
        await Task.Delay(l_iMilSecs);
        VolumeMeter.Value = 50;
        await Task.Delay(l_iMilSecs);
        VolumeMeter.Value = 60;
    }
