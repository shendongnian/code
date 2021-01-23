    [BroadcastReceiver(Enabled = true, Label = "SMS Receiver")]
	[IntentFilter(new[] { "android.provider.Telephony.SMS_RECEIVED" })] 
	public class SMSBroadcastReceiver : BroadcastReceiver, ISMSReceiver
	{
		private const string Tag = "SMSBroadcastReceiver";
		private const string IntentAction = "android.provider.Telephony.SMS_RECEIVED"; 
		public override void OnReceive(Context context, Intent intent)
		{
			Log.Info(Tag, "Intent received: " + intent.Action);
			if (intent.Action != IntentAction) return;
			SmsMessage[] messages=Telephony.Sms.Intents.GetMessagesFromIntent (intent);
			var sb = new StringBuilder();
			for (var i = 0; i < messages.Length; i++)
			{
				sb.Append(string.Format("SMS From: {0}{1}Body: {2}{1}", messages[i].OriginatingAddress,
					Environment.NewLine,messages[i].MessageBody));
			}
		}
	}
