    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Un4seen.Bass;
    using Un4seen.Bass.Misc;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero))
                    throw new InvalidOperationException("Couldn't initialize BASS");
    
                string fileName = @"D:\Brothers Vibe - Rainforest.mp3";
                var segments = new double[] {30, 15, 20};
                string[] splitAudio = SplitAudio(fileName, segments, "output", @"D:\split");
            }
    
            private static string[] SplitAudio(string fileName, double[] segments, string prefix, string outputDirectory)
            {
                if (fileName == null) throw new ArgumentNullException("fileName");
                if (segments == null) throw new ArgumentNullException("segments");
                if (prefix == null) throw new ArgumentNullException("prefix");
                if (outputDirectory == null) throw new ArgumentNullException("outputDirectory");
                int i = Bass.BASS_StreamCreateFile(fileName, 0, 0,
                    BASSFlag.BASS_STREAM_PRESCAN | BASSFlag.BASS_STREAM_DECODE);
                if (i == 0)
                    throw new InvalidOperationException("Couldn't create stream");
    
                double sum = segments.Sum();
    
                long length = Bass.BASS_ChannelGetLength(i);
                double seconds = Bass.BASS_ChannelBytes2Seconds(i, length);
                if (sum > seconds)
                    throw new ArgumentOutOfRangeException("segments", "Required segments exceed file duration");
                BASS_CHANNELINFO info = Bass.BASS_ChannelGetInfo(i);
    
                if (!Directory.Exists(outputDirectory)) Directory.CreateDirectory(outputDirectory);
    
                int index = 0;
                var list = new List<string>();
                foreach (double segment in segments)
                {
                    double d = segment;
                    long seconds2Bytes = Bass.BASS_ChannelSeconds2Bytes(i, d);
                    var buffer = new byte[seconds2Bytes];
                    int getData = Bass.BASS_ChannelGetData(i, buffer, buffer.Length);
                    string name = string.Format("{0}_{1}.wav", prefix, index);
                    string combine = Path.Combine(outputDirectory, name);
                    int bitsPerSample = info.Is8bit ? 8 : info.Is32bit ? 32 : 16;
                    var waveWriter = new WaveWriter(combine, info.chans, info.freq, bitsPerSample, true);
                    waveWriter.WriteNoConvert(buffer, buffer.Length);
                    waveWriter.Close();
                    list.Add(combine);
                    index++;
                }
                bool free = Bass.BASS_StreamFree(i);
    
                return list.ToArray();
            }
        }
    }
