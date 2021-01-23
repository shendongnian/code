      void ConversationManager_ConversationAdded(object sender, Microsoft.Lync.Model.Conversation.ConversationManagerEventArgs e)
        {
            var audioProperty = e.Conversation.Modalities[Microsoft.Lync.Model.Conversation.ModalityTypes.AudioVideo].Properties;
            audioProperty[Microsoft.Lync.Model.Conversation.ModalityProperty.AVModalityAudioCaptureMute] = true;
        }
