     private void ProcessMessage(String message)
        {
            
            string[] messages = message.Split(new String[] { END_PACKET }, StringSplitOptions.RemoveEmptyEntries);
            foreach(String msg in messages)
            {
                string singleMessage = msg;
                if (msg.Contains(END_PACKET))
                    singleMessage = msg.Substring(0, msg.LastIndexOf(END_PACKET));
                notify("Received : " + singleMessage);
                Request request = JsonConvert.DeserializeObject<Request>(singleMessage);
                onMessageReseived(request);
            }
        }
