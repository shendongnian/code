    using System.Threading;
    using System.Collections.Concurrent;
    namespace PlaySound
    {
        public partial class Form1 : Form
        {
            private Thread soundPlayThread;
            private BlockingCollection<string> speakQueue = new BlockingCollection<string>();
            private CancellationTokenSource cancelSoundPlay;
            private int soundPlayCount = 0;
    
            public Form1()
            {
                InitializeComponent();
                cancelSoundPlay = new CancellationTokenSource();
            }
    
            private void btnStartSoundPlay_Click(object sender, EventArgs e)
            {
                StartSoundPlay();
            }
    
            private void btnStopSoundPlay_Click(object sender, EventArgs e)
            {
                cancelSoundPlay.Cancel();
                Console.WriteLine("Sound play cancelled.");
            }
    
            private void btnAddToQueue_Click(object sender, EventArgs e)
            {
                speakQueue.Add("MyFile.wav");
            }
			
            private void queueAndPlay(string loc)
            {
                if (!File.Exists(loc=loc+".wav"))
                    loc=configPath+"soundnotfound.wav";
                speakQueue.Add(loc);
				StartSoundPlay();
            }
    	
    
            private void StartSoundPlay()
            {
                //Sound Player Loop Thread
                if (this.soundPlayThread == null || !this.soundPlayThread.IsAlive)
                {
                    this.soundPlayThread = new Thread(SoundPlayerLoop);
                    this.soundPlayThread.Name = "SoundPlayerLoop";
                    this.soundPlayThread.IsBackground = true;
                    this.soundPlayThread.Start();
                    Console.WriteLine("Sound play started");
                }
            }
            //Method that the outside thread will use outside the thread of this class
            private void SoundPlayerLoop()
            {
                var sound = new SoundPlayer();
                foreach (String soundToPlay in this.speakQueue.GetConsumingEnumerable(cancelSoundPlay.Token))
                {
                    //http://msdn.microsoft.com/en-us/library/system.media.soundplayer.playsync.aspx
                    speaker.SoundLocation=soundToPlay;
                    //Here the outside thread waits for the following play to end before continuing.
                    sound.PlaySync();
                    soundPlayCount++;
                    Console.WriteLine("Sound play end. Count: " + soundPlayCount);
                }
            }
        }
    }
