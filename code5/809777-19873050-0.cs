    private void Read()
        {
            StreamReader r = new StreamReader(clientObject.GetStream());
            string str;
            while (!(String.IsNullOrEmpty(str=r.ReadLine())))
            {
                Client_dataReceived(str);
            }
        }
