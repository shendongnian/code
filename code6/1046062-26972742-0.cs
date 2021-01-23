    private void sendEmailThread(string ALICI, string KONU, string body_)
    {
        this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate() { 
                         var result = sendEmail(ALICI, KONU, body_); 
                         SomeDBUpdate(result);
                         } );
    }
