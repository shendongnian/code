    private async void DoSomething()
    {
        for (int i = 0; i < 3; i++) 
        {
            if ((_currentGridPos >= 0 && _currentGridPos < 2) || (_currentGridPos >= 3 && _currentGridPos < 5))
            {
                pictureBox1.Image = Image.FromFile(@"C:\Users\Nyago\Images\g" + _currentGridPos + "_r" + i + ".JPG");
                pictureBox1.Refresh();
                await Task.Delay(200);//<--Note Task.Delay don't block UI
            }
        }
    }
