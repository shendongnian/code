    <StackPanel Orientation="Vertical">
        <ProgressBar Name="myPb" Minimum="0" Maximum="100" Height="20"></ProgressBar>
        <Button Click="ButtonBase_OnClick">Press me</Button>
    </StackPanel>
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(delegate()
            {
                for (int i = 0; i < 100; i++)
                {
                    this.Dispatcher.Invoke(new Action(delegate()
                    {
                        myPb.Value = i;
                    })); 
                    Thread.Sleep(500);
                }
            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
