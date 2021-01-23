        private static void CallHandler(object sender, EventHandler eventHandler)
        {
            if (eventHandler != null)
            {
                if (syncContext != null)
                {
                    syncContext.Post((o) => eventHandler(sender,  EventArgs.Empty), null);
                }
                else
                {
                    eventHandler(sender, EventArgs.Empty);
                }
            }
        }
