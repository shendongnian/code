    txtResultSharing.Text = string.Format("I have earned {0} points in {1} levels", y.ToString(), x.ToString());
    txtResultSharing1.Text = string.Format("I have earned {0} points in {1} levels", y.ToString(), x.ToString());
    ResultGrid.Visibility = Visibility.Visible;
    ResultGrid.UpdateLayout();
    _timer.Start();
