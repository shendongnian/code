    private void SendSMSs(List<SMS> smsList)
    {
        Thread thread = new Thread(new ThreadStart(SendOneSMS));
    }
    private void SendOneSMS()
    {
        SendSMS smsSend = new SendSMS(sms.message, sms.number, 0, SmsResponseCallback);
        Console.WriteLine("Sent a SMS to " + sms.number);
    }
