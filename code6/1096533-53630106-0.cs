        // Called when the instant messaging session changes state
        void instantMessagingCall_StateChanged(object sender, CallStateChangedEventArgs e)
        {
            string diagnostics = "";
            foreach (SignalingHeader header in e.MessageData.SignalingHeaders)
            {
               // Capture all flavors of diagnostic headers
                            if (header.Name.Equals("ms-diagnostics", StringComparison.InvariantCultureIgnoreCase))
                            {
                                diagnostics = diagnostics + header.GetValue() + ";";
                            }
                            if (header.Name.Equals("ms-diagnostics-public", StringComparison.InvariantCultureIgnoreCase)) // These are the public diagnostics in case you go over edge 
                            {
                                diagnostics = diagnostics + header.GetValue() + ";";
                            }
                            if (header.Name.Equals("Ms-client-diagnostics", StringComparison.InvariantCultureIgnoreCase)) // These are the client diagnostics
                            {
                                diagnostics = diagnostics + header.GetValue() + ";";
                                break;
                            }
            }
            if (diagnostics.Contains("51004") || diagnostics.Contains("Action initiated by user"))
            { 
                   // handle the case where the Action is initiated by the user, which is when the user closes the chat using the cross button
            }
            if (diagnostics.Contains("52094") || diagnostics.Contains("Instant Messaging conversation terminated on user inactivity")) 
            {
                   // the user left the window inactive for more than 10 minutes
            }
            if (diagnostics.Contains("52107") || diagnostics.Contains("Call terminated on signout") ) 
            {
                    // the user signed out of Lync/Skype while the conversation is still active
            }
            if (diagnostics.Contains("52082") || diagnostics.Contains("Session is detached from conversation"))
            {
                    // when the user clicks on "Deny" after receving the invite
            }
