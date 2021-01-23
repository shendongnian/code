        public Form1()
        {
            InitializeComponent();
            
            List<RadioProgrammeDetails> Programmes = new List<RadioProgrammeDetails>();
            using (StreamReader sr = new StreamReader("musor.txt"))
            {
                int n_lines = Convert.ToInt32(sr.ReadLine());
                for (int i = 0; i < n_lines; i++)
                {
                    string [] data = sr.ReadLine().Split(new char[] { ' ' }, 4);
                    int channel = 0;
                    int minutes = 0;
                    int seconds = 0;
                    string artist = "";
                    string song = "";
                    int.TryParse(data[0], out channel);
                    int.TryParse(data[1], out minutes);
                    int.TryParse(data[2], out seconds);
                    string[] artistSong = data[3].Split(new char[] { ':' });
                    artist = artistSong[0];
                    song = artistSong[1];
                    Programmes.Add(new RadioProgrammeDetails() { Artist = artist, SongName = song, Channel = channel, Length = new TimeSpan(0, minutes, seconds) });
                }
                var radioOne = Programmes.Where(x => x.Channel == 1);
                double elapsedSeconds = radioOne.SkipWhile(x => x.Artist != "Eric Clapton").Reverse().SkipWhile(x=>x.Artist!="Eric Clapton").Sum(x=>x.Length.TotalSeconds);
                Console.WriteLine(elapsedSeconds);
            }
        }
        public class RadioProgrammeDetails
        {
            public int Channel { get; set; }
            public TimeSpan Length { get; set; }
            public string Artist { get; set; }
            public string SongName { get; set; }
        }
