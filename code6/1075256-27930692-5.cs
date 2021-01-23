            string signal = "R3MEXA";
            string newId = "1";
            byte[] asciiBytes = System.Text.Encoding.ASCII.GetBytes(signal);
            foreach (byte b in asciiBytes)
                newId += b.ToString().PadLeft(3,'0'); //Add Zero, if the byte has less than 3 digits
            double signalInt = Double.Parse(newId);
            //Convert it back
            List<byte> bytes = new List<byte>(); //Create a list, we don't know how many bytes will come (Or you calc it: maximum is _signal / 3)
            //string _signal = signalInt.ToString("F0"); //Maybe you know a better way to get the double to string without scientific
            //This is my workaround to get the integer part from the double:
            //It's not perfect, but  I don't know another way at the moment without losing information
            string _signal = "";
            while (signalInt > 1)
            {
                int _int = (int)(signalInt % 10);
                _signal += (_int).ToString();
                signalInt /= 10;
            }
            _signal = String.Join("",_signal.Reverse());
            for (int i = 1; i < _signal.Length; i+=3)
            {
                byte b = Convert.ToByte(_signal.Substring(i, 3)); //Make 3 digits to one byte
                if(b!=0) //With the ToString("F0") it is possible that empty bytes are at the end
                bytes.Add(b);
            }
            string result = System.Text.Encoding.ASCII.GetString(bytes.ToArray()); //Yeah "R3MEX" The "A" is lost, because double can't hold that much.
