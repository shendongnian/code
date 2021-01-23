    private async Task OnValueChangeImplAsync()
    {
      var progress = new Progress<int>(i => ProgresBar.Value = i);
      Image im = await Task.Run(() => MyStaticClass.MyStaticFunction(progress));
      Picture = im;
      _onValueChangeTask = null;
    }
    private Task _onValueChangeTask;
    public Task OnValueChangeAsync()
    {
      if (_onValueChangeTask != null)
        return _onValueChangeTask;
      _onValueChangeTask = OnValueChangeImplAsync();
      return _onValueChangeTask;
    }
    public async void OnValueChange(object sender, EventArgs e) 
    {
      await OnValueChangeAsync();
    }
