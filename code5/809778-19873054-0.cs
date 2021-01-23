     private void Read()
        {
            using (var r = new StreamReader(clientObject.GetStream()))
            {
                string str;
                while ((str = r.ReadLine()) != null)
                {
                    Client_dataReceived(str);
                }
                Disconnect();
            }
        }
