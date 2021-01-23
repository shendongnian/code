    // API method with Thread.Sleep as requested
    public static int GetAnswer() {
        Thread.Sleep(5000);
        return 42;
    }
    // Code assumes to be inside some kind of "Window" class where there is a Dispatcher
    public void SomeButton_OnClick(object sender, EventArgs e) {
        Task.Run(() => {
            int answer = GetAnswer();
            Dispatcher.BeginInvoke(() => {
               MyLabel.Text = answer;
            });
        });
    }
