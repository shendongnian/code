    private void SendSMSs(List<SMS> smsList)
    {
        foreach(SMS sms in smsList)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(SendOneSMS(sms)));
        }
    }
    private void SendOneSMS(SMS sms)
    {
        SendSMS smsSend = new SendSMS(sms.message, sms.number, 0, SmsResponseCallback);
        Console.WriteLine("Sent a SMS to " + sms.number);
    }
