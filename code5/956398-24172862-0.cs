    private static string GetPlainTextFromMessageBody(MimeMessage message)
        {
            //content type needs to match text/plain otherwise i would store html into DB
            var mimeParts = message.BodyParts.Where(bp => bp.IsAttachment == false && bp.ContentType.Matches("text", "plain"));
            foreach (var mimePart in mimeParts)
            {
                if (mimePart.GetType() == typeof(TextPart))
                {
                    var textPart = (TextPart)mimePart;
                    return textPart.Text;
                }
            }
            return String.Empty;
        }
