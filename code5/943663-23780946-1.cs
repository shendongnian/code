        void BoardConnecion()
        {
            while(true)
            {
                foreach (var item in SerialPort.GetPortNames())
                {
                    if (item == "COM3")
                    {
                        boardjoined = true;
                        DisplayImage(_pic_usb, "on.png");
                    }
                    else
                    {
                        boardjoined = false;
                        DisplayImage(_pic_usb, "off.png");
                    }
                }
                Thread.Sleep(500);
            }
        }
