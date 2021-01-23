        public void TakeBackward(int distanceTime, SerialPort port)
        {
            int count = 0;
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                while (true)
                {
                    port.WriteLine("B");
                    if (count >= distanceTime)
                    {
                        break;
                    }
					else
					{
						Thread.Sleep(distanceTime * 250);
						count++;
					}
                }
            }));
            thread.IsBackground = true;
            thread.Start();
        }
