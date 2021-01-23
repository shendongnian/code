	using System;
	using NAudio.Lame;
	using NAudio.Wave;
	namespace MP3Rec
	{
		class Program
		{
			static LameMP3FileWriter wri;
			static bool stopped = false;
			static void Main(string[] args)
			{
				// Setup MP3 writer to output at 32kbit/sec (~2 minutes per MB)
				wri = new LameMP3FileWriter(@"C:\temp\test_output.mp3", waveIn.WaveFormat, 32);
				// Start recording from loopback
				IWaveIn waveIn = new WasapiLoopbackCapture();
				waveIn.DataAvailable += waveIn_DataAvailable;
				waveIn.RecordingStopped += waveIn_RecordingStopped;
				waveIn.StartRecording();
				stopped = false;
				// Keep recording until Escape key pressed
				while (!stopped)
				{
					if (Console.KeyAvailable)
					{
						var key = Console.ReadKey(true);
						if (key != null && key.Key == ConsoleKey.Escape)
							waveIn.StopRecording();
					}
					else
						System.Threading.Thread.Sleep(50);
				}
				// flush output to finish MP3 file correctly
				wri.Flush();
				// Dispose of objects
				waveIn.Dispose();
				wri.Dispose();
			}
			static void waveIn_RecordingStopped(object sender, StoppedEventArgs e)
			{
				// signal that recording has finished
				stopped = true;
			}
			static void waveIn_DataAvailable(object sender, WaveInEventArgs e)
			{
				// write recorded data to MP3 writer
				if (wri != null)
					wri.Write(e.Buffer, 0, e.BytesRecorded);
			}
		}
	}
