    public class Recorder
    {
        
        /// <summary>
        /// Timer used to start/stop recording
        /// </summary>
        private Timer _timer;
        private WaveInEvent _waveSource;
        private WaveFileWriter _waveWriter;
        private string _filename;
        private string _tempFilename;
        public event EventHandler RecordingFinished;
        /// <summary>
        /// Record from the mic
        /// </summary>
        /// <param name="seconds">Duration in seconds</param>
        /// <param name="filename">Output file name</param>
        public void RecordAudio(int seconds, string filename)
        {
            /*if the filename is empty, throw an exception*/
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("The file name cannot be empty.");
            /*if the recording duration is not > 0, throw an exception*/
            if (seconds <= 0)
                throw new ArgumentNullException("The recording duration must be a positive integer.");
            _filename = filename;
            _tempFilename = $"{Path.GetFileNameWithoutExtension(filename)}.wav";
            _waveSource = new WaveInEvent
            {
                WaveFormat = new WaveFormat(44100, 1)
            };
            _waveSource.DataAvailable += DataAvailable;
            _waveSource.RecordingStopped += RecordingStopped;
            _waveWriter = new WaveFileWriter(_tempFilename, _waveSource.WaveFormat);
            /*Start the timer that will mark the recording end*/
            /*We multiply by 1000 because the Timer object works with milliseconds*/
            _timer = new Timer(seconds * 1000);
            /*if the timer elapses don't reset it, stop it instead*/
            _timer.AutoReset = false;
            /*Callback that will be executed once the recording duration has elapsed*/
            _timer.Elapsed += StopRecording;
            /*Start recording the audio*/
            _waveSource.StartRecording();
            /*Start the timer*/
            _timer.Start();
            
        }
        /// <summary>
        /// Callback that will be executed once the recording duration has elapsed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopRecording(object sender, ElapsedEventArgs e)
        {
            /*Stop the timer*/
            _timer?.Stop();
            /*Destroy/Dispose of the timer to free memory*/
            _timer?.Dispose();
            /*Stop the audio recording*/
            _waveSource.StopRecording();
        }
        
        /// <summary>
        /// Callback executed when the recording is stopped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecordingStopped(object sender, StoppedEventArgs e)
        {
            _waveSource.DataAvailable -= DataAvailable;
            _waveSource.RecordingStopped -= RecordingStopped;
			_waveSource?.Dispose();
			_waveWriter?.Dispose();
			
            /*Convert the recorded file to MP3*/
            ConvertWaveToMp3(_tempFilename, _filename);
            /*Send notification that the recording is complete*/
            RecordingFinished?.Invoke(this, null);
        }
        /// <summary>
        /// Callback executed when new data is available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataAvailable(object sender, WaveInEventArgs e)
        {
            if (_waveWriter != null)
            {
                _waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
                _waveWriter.Flush();
            }
        }
        /// <summary>
        /// Converts the recorded WAV file to MP3
        /// </summary>
        private void ConvertWaveToMp3(string source, string destination)
        {
            using (var waveStream = new WaveFileReader(source))
            using(var fileWriter = new LameMP3FileWriter(destination, waveStream.WaveFormat, 128))
            {
                waveStream.CopyTo(fileWriter);
                waveStream.Flush();
            }
            /*Delete the temporary WAV file*/
            File.Delete(source);
        }
        
    }
