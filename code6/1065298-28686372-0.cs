       public void SendResponse(int command, Object[] args)
        {
            if (ClientSocket == null)
            {
                Console.WriteLine("Command: ClientSocket");
                return;
            }
            var serverStream = this.ClientSocket.GetStream();
            if (!serverStream.CanRead || !serverStream.CanWrite)
            {
                Console.WriteLine("Command: serverStream Error");
                return;
            }
            byte[] toSend = null;
            switch (command)
            {
                // 0 - genneral, 1 - handshake response
                case 0:
                    toSend = Encoding.ASCII.GetBytes(args[0].ToString());
                    break;
                case 1:
                    Rectangle bounds = Screen.GetBounds(Point.Empty);
                    using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format16bppRgb555))
                    {
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                        }
                        toSend = ImageToByte(bitmap);
                    }
                    break;
            }
            try
            {
    //--- Framing occurs here mainly
                byte[] bufferedToSend = new byte[toSend.Length + 4];
                byte[] lengthOfSend = BitConverter.GetBytes(toSend.Length);
                Array.Copy(lengthOfSend, bufferedToSend, 4);
                toSend.CopyTo(bufferedToSend, 4);
                serverStream.Write(bufferedToSend, 0, bufferedToSend.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
