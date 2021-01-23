        private async Task SendGridasyncBid(string from, string to, string  displayName, string subject, **byte[] PDFBody**, string TxtBody, string HtmlBody)
            {
                ...
                var myStream =  new System.IO.MemoryStream(**PDFBody**);
                myStream.Seek(0, SeekOrigin.Begin);
                myMessage.AddAttachment(myStream, "NewBid.pdf");
                ...
            }
