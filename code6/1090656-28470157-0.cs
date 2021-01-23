    // 'async' keyword is important!
    async void foo()
    {
      bleep.Play(); // play bleep
      await System.Threading.Tasks.Task.Delay(1100);
      this.Frame.Navigate(typeof(MainPage.ItemPage));
    }
