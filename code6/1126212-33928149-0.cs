    if (_conversation != null &&
        _conversation.CanSetProperty(ConversationProperty.ConferenceVideoHardMute))
    {
        _conversation.BeginSetProperty(ConversationProperty.ConferenceVideoHardMute, value, ar =>
        {
            if (ar.IsCompleted)
            {
                try
                {
                    _conversation.EndSetProperty(ar);
                }
                catch (Exception exception)
                {
                     // exception handling
                }
            }
        }, null);
    }
