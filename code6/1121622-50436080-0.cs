    public partial class MainWindow : Window
    {
        AsioOut ASIODriver;
        BufferedWaveProvider buffer;
        public MainWindow()
        {
            String[] drivernames = AsioOut.GetDriverNames();
            ASIODriver = new AsioOut(drivernames[0]);
            buffer = new BufferedWaveProvider(new WaveFormat ());
            ASIODriver.AudioAvailable += new EventHandler<AsioAudioAvailableEventArgs>(ASIODriver_AudioAvailable);
            ASIODriver.InitRecordAndPlayback(buffer,2,44100);
            ASIODriver.Play();       
        }
        private void ASIODriver_AudioAvailable(object sender, AsioAudioAvailableEventArgs e)
        {
            //byte[] buf = new byte[e.SamplesPerBuffer];
            byte[] buf = new byte[e.SamplesPerBuffer*4];
            for (int i = 0; i < e.InputBuffers.Length; i++)
            {
               //Marshal.Copy(e.InputBuffers[i], buf, 0, e.SamplesPerBuffer);
               //Marshal.Copy(buf, 0, e.OutputBuffers[i], e.SamplesPerBuffer);
               Marshal.Copy(e.InputBuffers[i], buf, 0, e.SamplesPerBuffer*4);
               Marshal.Copy(buf, 0, e.OutputBuffers[i], e.SamplesPerBuffer*4);
            }
            e.WrittenToOutputBuffers = true;
        }
    }
