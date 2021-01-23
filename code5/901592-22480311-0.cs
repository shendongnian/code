    private void ConversationManager_ConversationAdded(object sender, ConversationManagerEventArgs e)
    {
        _conversation = e.Conversation;
        _conversation.StateChanged += Conversation_StateChanged;
        _conversation.ParticipantAdded += Conversation_ParticipantAdded;
    
        var contact = _client.ContactManager.GetContactByUri("+441234567890");
        _conversation.AddParticipant(contact);
    }
    
    private void Conversation_ParticipantAdded(object sender, ParticipantCollectionChangedEventArgs e)
    {
        if (!e.Participant.IsSelf)
        {
            _avModality = (AVModality)_conversation.Modalities[ModalityTypes.AudioVideo];
            _avModality.ModalityStateChanged += AudioVideoModality_ModalityStateChanged;
    
            if (_avModality.CanInvoke(ModalityAction.Connect))
            {
                _avModality.BeginConnect(AVModalityConnectCallback, _avModality);
            }
        }
    }
    private void AVModalityConnectCallback(IAsyncResult ar)
    {
        _avModality.EndConnect(ar);
    }
