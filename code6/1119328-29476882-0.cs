    string hex = "";
                 foreach (char c in RXstring)
                 {
                     int tmp = c;
                     hex += String.Format("{0:X2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
                 }
                 textBox5.AppendText(hex);
