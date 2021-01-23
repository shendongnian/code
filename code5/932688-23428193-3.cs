    private async void removeGameButton_Click(object sender, RoutedEventArgs e)
    {
       await DoWork();
    }
    private async Task DoWork()
    {
         Task<MessageDialogResult> result = await this.ShowMessageAsync("Hi", "Message", MessageDialogStyle.AffirmativeAndNegative);
         if(result.Result == MessageDialogResult.Negative)
         {
             Console.WriteLine("No");
         }
         else
         {
             Console.WriteLine("yes");
         }
    }
