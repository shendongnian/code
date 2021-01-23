    namespace PlaySound
    {
        public partial class Form1 : Form
        {
            private Thread soundPlayThread;
            private BlockingCollection<string> soundToPlayCollection = new BlockingCollection<string>();
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
                soundToPlayCollection.Add("MyFile.wav");
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
    
            private void SoundPlayerLoop()
            {
                foreach (String soundToPlay in this.soundToPlayCollection.GetConsumingEnumerable(cancelSoundPlay.Token))
                {
                    //http://msdn.microsoft.com/en-us/library/system.media.soundplayer.playsync.aspx
                    var sound = new SoundPlayer(soundToPlay);
                    sound.PlaySync();
                    soundPlayCount++;
                    Console.WriteLine("Sound play end. Count: " + soundPlayCount);
                }
            }
        }
    }
