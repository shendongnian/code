     ((SolidColorBrush)App.Current.Resources["PhoneChromeBrush"]).Color =  GetColorFromHexa("#123C8E").Color;
    
      public SolidColorBrush GetColorFromHexa(string hexaColor)
           {
               byte R = Convert.ToByte(hexaColor.Substring(1, 2), 16);
               byte G = Convert.ToByte(hexaColor.Substring(3, 2), 16);
               byte B = Convert.ToByte(hexaColor.Substring(5, 2), 16);
               SolidColorBrush scb = new SolidColorBrush(Color.FromArgb(0xFF, R, G, B));
               return scb;
           }
