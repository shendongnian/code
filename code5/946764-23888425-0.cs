        private void PipeClientWorker()
        {
            //Client
            var client = new NamedPipeClientStream(".", "kinect-pipe", PipeDirection.In);
            client.Connect();
            while (_isWorkerRunning)
            {
                using (var sr = new StreamReader(client))
                {
                    string temp;
                    while ((temp = sr.ReadLine()) != null)
                    {
                        // TODO figure out how to do this in the right thread
                        if (KinectHandler != null)
                        {
                            KinectHandler.BeginInvoke(temp, null, null);
                        }
                    }
                }
                if (!client.IsConnected)
                {
                    client.Connect();
                }
            }
            client.Flush();
            client.Close();
        }
