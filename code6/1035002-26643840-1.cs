        private void EventProviderOnExecuteMsiMessage(object sender, ExecuteMsiMessageEventArgs executeMsiMessageEventArgs)
        {   
            if (executeMsiMessageEventArgs.MessageType == InstallMessage.Warning)
            {            
                    var theActualMessage = executeMsiMessageEventArgs.Data.ToList();
                    //do something with theActualMessage here...
            }
        }
