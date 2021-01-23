    private CancellationTokenSource _cts;
    async Task SetSoundSourceAsync(string path)
    {
      if (_cts != null)
        _cts.Cancel();
      _cts = new CancellationTokenSource();
      var token = _cts.Token;
      var result = await Task.Run(() => CodecFactory.Instance.GetCodec(path));
      if (token.IsCancellationRequested)
        return;
      SoundSource = result;
    }
