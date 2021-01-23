        context.SendingRequest2 += (sender, eventArgs) =>
            {
                // We can safely cast RequestMessage to HttpWebRequestMessage if this is not in batch.
                if (!eventArgs.IsBatchPart)
                {
                    ((HttpWebRequestMessage)eventArgs.RequestMessage).HttpWebRequest.ClientCertificates.Add(theCertificate);
                }
            };
