        public static byte[] GetUserImage(string image_name)
        {
            Pop3Client c = new Pop3Client();
            c.Connect("pop.gmail.com", 995, true);
            c.Authenticate("your gmail", "password");
            for (int i = c.GetMessageCount(); i >= 1; i--)
            {
                OpenPop.Mime.Message mess = c.GetMessage(i);
                if (mess.Headers.Subject.Equals(image_name))
                {
                   return mess.MessagePart.MessageParts[1].Body;//this to get attachment
                                                **OR:**
                   return Encoding.ASCII.GetString(mess.MessagePart.Body);//this to get text
                }
            }
            return null ;
        }
