            private float bigValue;
        WaveIn waveIn;
        private double MaxValue;
        private void button1_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Convert.ToInt16(textBox1.Text) > 100)
            {
                MessageBox.Show("Invalid Value");
                return;
            }
            else
                MaxValue = Convert.ToDouble(textBox1.Text) / 100;
            bigValue = 0;
            waveIn = new WaveIn();
            int waveInDevices = waveIn.DeviceNumber;
            //Get Device Count
            for (int waveInDevice = 0; waveInDevice < waveInDevices; waveInDevice++)
            {
                WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(waveInDevice);
            }
            waveIn.DeviceNumber = 0;
            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            int sampleRate = 8000;
            int channels = 1;
            waveIn.WaveFormat = new WaveFormat(sampleRate, channels);
            waveIn.StartRecording();
        }
        private void button1_Loaded(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(textBox1.Text) > 100)
            {
                MessageBox.Show("Invalid Value");
                return;
            }
            else
                MaxValue = Convert.ToDouble(textBox1.Text) / 100;
            bigValue = 0;
            waveIn = new WaveIn();
            int waveInDevices = waveIn.DeviceNumber;
            for (int i = 0; i <= 100; i++)
            {
            }
            //Get Device Count
            for (int waveInDevice = 0; waveInDevice < waveInDevices; waveInDevice++)
            {
                WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(waveInDevice);
            }
            waveIn.DeviceNumber = 0;
            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            int sampleRate = 8000;
            int channels = 1;
            waveIn.WaveFormat = new WaveFormat(sampleRate, channels);
            waveIn.StartRecording();
        }
        int i = 0;
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            for (int index = 0; index < e.BytesRecorded; index += 2)
            {
                short sample = (short)((e.Buffer[index + 1] << 8) | e.Buffer[index + 0]);
                float sample32 = sample / 32768f;
                label1.Content = sample32.ToString();
                if (bigValue < sample32)
                {
                    bigValue = sample32;
                    label2.Content = bigValue.ToString();
                    if (bigValue > MaxValue)
                    {
                        waveIn.StopRecording();
                        if (IsOdd(i))
                        {
                            button1.IsEnabled = false;
                        }
                        else
                        {
                            button1.IsEnabled = true;
                        }
                        MessageBox.Show("Did you Clap?");
                        i++;
                    }
                }
            }
        }
        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
    }
