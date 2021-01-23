    public static class InboundEmailExtractor
    {
        public async static Task<InboundEmailInputModel> ExtractInboundEmail(HttpRequestBase request)
        {
            var serialiser = new JavaScriptSerializer();
            var inboundEmail = new InboundEmailInputModel();
            inboundEmail.Headers = request.Unvalidated.Form["headers"];
            inboundEmail.Text = request.Unvalidated.Form["text"];
            inboundEmail.Html = request.Unvalidated.Form["html"];
            inboundEmail.From = request.Unvalidated.Form["from"];
            inboundEmail.To = request.Unvalidated.Form["to"];
            inboundEmail.Cc = request.Unvalidated.Form["to"].Split(',').ToList();
            inboundEmail.Subject = request.Unvalidated.Form["subject"];
            inboundEmail.Dkim = request.Unvalidated.Form["dkim"];
            inboundEmail.Spf = request.Unvalidated.Form["spf"];
            var envelopeRaw = request.Unvalidated.Form["envelope"];
            if (envelopeRaw != null)
            {
                inboundEmail.Envelope = serialiser.Deserialize<InboundEmailEnvelopeInputModel>(envelopeRaw);
            }
            var charsetsRaw = request.Unvalidated.Form["charsets"];
            if (charsetsRaw != null)
            {
                inboundEmail.Charsets =
                    new JavaScriptSerializer().Deserialize<InboundEmailCharsetsInputModel>(charsetsRaw);
            }
            var spamScoreRaw = request.Unvalidated.Form["spam_score"];
            if (spamScoreRaw != null)
            {
                inboundEmail.SpamScore = float.Parse(spamScoreRaw, CultureInfo.InvariantCulture.NumberFormat);
            }
            inboundEmail.SpamReport = request.Unvalidated.Form["spam_report"];
            var attachmentsRaw = request.Unvalidated.Form["attachments"];
            if (attachmentsRaw != null)
            {
                inboundEmail.Attachments = Convert.ToInt32(attachmentsRaw);
            }
            var attachmentInfoRaw = request.Unvalidated.Form["attachment-info"];
            if (attachmentInfoRaw != null)
            {
                inboundEmail.AttachmentInfo = System.Web.Helpers.Json.Decode(attachmentInfoRaw);
            }
            inboundEmail.SenderIp = request.Unvalidated.Form["sender_ip"];
            inboundEmail.AttachmentFiles = request.Files;
            return inboundEmail;
        }
    }
