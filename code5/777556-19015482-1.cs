    var sec = (AsymmetricSecurityBindingElement)SecurityBindingElement.CreateMutualCertificateBindingElement(MessageSecurityVersion.WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10);
                sec.EndpointSupportingTokenParameters.Signed.Add(new UserNameSecurityTokenParameters());
                sec.MessageSecurityVersion =
                    MessageSecurityVersion.
                        WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10;
                sec.IncludeTimestamp = false;
                sec.MessageProtectionOrder = System.ServiceModel.Security.MessageProtectionOrder.EncryptBeforeSign;
    
                b.Elements.Add(sec);
                b.Elements.Add(new TextMessageEncodingBindingElement(MessageVersion.Soap11, Encoding.UTF8));
                b.Elements.Add(new HttpsTransportBindingElement());
