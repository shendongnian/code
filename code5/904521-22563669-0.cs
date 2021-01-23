    public void send()
    {
        Action dispAc = () => NameAsync();
        _dispatcher.BeginInvoke(dispAc);
    }
