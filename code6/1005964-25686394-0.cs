    private string _lastValueSearched;
    private void TxtBoxAddress_KeyUp(object sender, KeyEventArgs e)
      {
        if (e.Key == Key.Enter && _lastValueSearched != TxtBoxAddress.Text)
          {
            //TxtBoxAddress.LoseFocus();
            btnSearch_Click(sender, e);
            _lastValueSearched = TxtBoxAddress.Text;
          }
      }
    private void queryTask_Failed(object sender, TaskFailedEventArgs e)
     {
        //throw new NotImplementedException();
        MessageBox.Show("*", "*", MessageBoxButton.OK);
        isMapNearZoomed = false;
     }
