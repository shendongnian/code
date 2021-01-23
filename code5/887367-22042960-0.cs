    private Task SendSMSs(List<SMS> smsList)
    {
        return Task.WhenAll(from sms in smsList select SendSMS(sms));
    }
    private Task SendSMS(SMS sms)
    {
        return Task.Run(() =>
        {
            SendSMS smsSend = new SendSMS(sms.message, sms.number, 0, SmsResponseCallback);
            Console.WriteLine("Sent a SMS to " + sms.number);
        });
    }
