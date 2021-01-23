        public void RequestLastMessage(JID jabberid)
        {
            try
            {
                LastIQ iq = new LastIQ(jabberClient1.Document);
                iq.To = jabberid;
                iq.Type = jabber.protocol.client.IQType.get;
                jabberClient1.Tracker.BeginIQ(iq, LastMessage, null);
            }
            catch (Exception ex)
            {
                DebugLogger.LogRecord(ex.Message + " [ Function: " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Class: XMPPWrapper ]");
            }
        }
        private void LastMessage(object sender, jabber.protocol.client.IQ iq, object state)
        {
            try
            {
                if ((iq == null) || (iq.Type != jabber.protocol.client.IQType.result))
                    return;
                Last ll = iq.Query as Last;
                if (iq.From != null && ll.Message != "")
                    if (ApplicationVariables.GlobalContactForm != null) ApplicationVariables.GlobalContactForm.SetOfflineStatus(ll.Message, iq.From);
            }
            catch (Exception ex)
            {
                DebugLogger.LogRecord(ex.Message + " [ Function: " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Class: XMPPWrapper ]");
            }
           
        }
