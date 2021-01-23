       public string GetImageFromByte(object byt)
          {
             byte[] byts = Convert.ToByte(byt);
             return byteArrayToImage(byts);
          }
