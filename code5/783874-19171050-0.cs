    public async Task OnValueChangeAsync() 
    {
      var progress = new Progress<int>(i => ProgresBar.Value = i);
      Image im = await Task.Run(() => MyStaticClass.MyStaticFunction(progress));
      Picture = im;
    }
    public async void OnValueChange(object sender, EventArgs e) 
    {
      await OnValueChangeAsync();
    }
