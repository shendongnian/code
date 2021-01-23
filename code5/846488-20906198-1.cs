        Cusbinding.Elements.Add(new TextMessageEncodingBindingElement()
        {
            MessageVersion = System.ServiceModel.Channels.MessageVersion.Default,
            WriteEncoding = System.Text.Encoding.UTF8
        });
        Cusbinding.Elements.Add(new HttpsTransportBindingElement());
