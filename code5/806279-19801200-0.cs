       byte[] byteArray = Encoding.UTF8.GetBytes(qrString);
       using (StreamReader reader = new StreamReader(new MemoryStream(byteArray)))
       {
          vCard card = new vCard(reader);
          // access here card.PropertyFromvCard to get the information you need
       }
