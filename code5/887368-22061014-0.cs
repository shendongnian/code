    private void SendSMSs(List<SMS> smsList)
    {
		var messagesSent = smsList.Select (s => SendSMS(s) ).ToArray();
		Task.WaitAll(messagesSent);
    }
	private Task<SMS_Result> SendSMS(SMS sms)
	{
		var tcs = new TaskCompletionSource<SMS_Result>();
		
		SendSMS smsSend = new SendSMS(sms.message, sms.number, 0, result =>
		{
			tcs.SetResult = result;
			Console.WriteLine("Succesfully sent a SMS to " + result.Destination + " with result: " + result.Result);
		});	
		
		Console.WriteLine("Sent a SMS to " + sms.number);
        return tcs.Task;
	}
