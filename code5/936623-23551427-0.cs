    public bool IsOnline() {
        var ping = new Ping();
        string host = "google.com";
        byte[] buffer = new byte[32];
        int timeout = 1000;
        var pingOptions = new PingOptions();
        PingReply reply = ping.Send(host, timeout, buffer, pingOptions);
        if (reply.Status == IPStatus.Success) {
          return true;
        }
        return false;
    }
