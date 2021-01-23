    [BroadcastReceiver]
    [IntentFilter(new string[]{PushHandlerService.UpdateAction}, Priority = (int)IntentFilterPriority.HighPriority)]
    public class UpdateSignalReceiver : BroadcastReceiver
    {
        private static List<Guid> _Last20MessageIds;
        public override void OnReceive(Context context, Intent intent)
        {       
            Guid MessageId;
            // Pull the MessageId from the intent
            String MessageIdString = intent.Extras.GetString("message_id" ?? Guid.Empty.ToString());
            Guid.TryParse(MessageIdString, out MessageId);
            
            
            if (_Last20MessageIds == null)
            {
                _Last20MessageIds = new List<Guid>();
            }
            // Make sure we didn't already receive this Message, then do work
            if (MessageId != null && MessageId != Guid.Empty && ! _Last20MessageIds.Contains(MessageId))
            {
                DoSomeWorkWithIntent(intent);
                        
                // Add the guid to the message id list
                _Last20MessageIds.Insert(0, MessageId);
                // Trim the list to the most recent 20
                _Last20MessageIds= _Last20MessageIds.Take(20).ToList();
            }
            InvokeAbortBroadcast();
        } // end on receive
    } // end UpdateSignalReceiver
