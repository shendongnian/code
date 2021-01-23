    /// <summary>
            /// Listen for messages from other ViewModels
            /// </summary>
            private void RegisterForMessages()
            {
                MessengerInstance.Register<bool>(this, UpdateMyStuff);
            }
    private void UpdateMyStuff(bool b)
            {
                IsEnabled=b;
            }
