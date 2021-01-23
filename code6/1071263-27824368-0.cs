        protected System.Web.UI.HtmlControls.HtmlGenericControl CreateEnvelopeTable(DocuSignAPI.EnvelopeStatus status)
        {
            var envelopeDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            int recipIndex = 0;
            foreach (DocuSignAPI.RecipientStatus recipient in status.RecipientStatuses)
            {
                var info = new System.Web.UI.HtmlControls.HtmlGenericControl("p");
                String recipId = "Recipient_Detail_" + status.EnvelopeID + "_" + recipient.RoutingOrder + "_" + recipient.UserName + "_" + recipient.Email + "_" + recipIndex++;
                info.InnerHtml = "<a href=\"javascript:toggle('" + recipId + "');\"><img src=\"images/plus.png\"></a> Recipient - " +
                    recipient.UserName + ": " + recipient.Status.ToString();
                if (recipient.Status != DocuSignAPI.RecipientStatusCode.Completed && null != recipient.ClientUserId)
                {
                    // For InPersonSigner, this will not work because the recipient.UserName needs to be the credentialed account actual user name, not the recipieint userName.
                    //info.InnerHtml += " <input type=\"submit\" id=\"" + status.EnvelopeID + "\" value=\"Start Signing\" name=\"DocEnvelope+" + status.EnvelopeID + "&Email+" + recipient.Email + "&UserName+" +
                    //    recipient.UserName + "&CID+" + recipient.ClientUserId + "\">";
                    
                    // In order to make this work for InPersonSigner, we need the envelope account (the credentialed account) userName instead of recipient.UserName
                    // Get correct user name depending on recipient type
                    string userName = (recipient.Type == RecipientTypeCode.InPersonSigner) ? status.ACHolder : recipient.UserName;
                    info.InnerHtml += " <input type=\"submit\" id=\"" + status.EnvelopeID + "\" value=\"Start Signing\" name=\"DocEnvelope+" + status.EnvelopeID + "&Email+" + recipient.Email + "&UserName+" +
                        userName + "&CID+" + recipient.ClientUserId + "\">";
                }
                if (null != recipient.TabStatuses)
                {
                    // Code here is the same, just making it shorter for this response
                }
                envelopeDiv.Controls.Add(info);
            }
            // Code between here and return is the same, just making it shorter for this response
            
            return envelopeDiv;
        }
