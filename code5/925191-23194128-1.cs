      private async void AwesomeButton_Click(object sender, EventArgs e)
      {
         doorLocked.FillColor = Color.Red;
         doorLight.FillColor = Color.SpringGreen;
         doorLockedImage.Visible = true;
         var cancellationToken = new CancellationTokenSource().Token;
         await Task.Delay(AmountOfMillisecondsHere, cancellationToken);
      }
