    internal class Program
    {
        private static readonly Regex LineMatch = new Regex( @"(\d+) (\d+) (\d+) (.*)", RegexOptions.Compiled );
        private static void Main( string[] args )
        {
            var filePath = @"";
            var songPlays = File.ReadAllLines( filePath ).Select( GetSongPlay );
            var totalTime = songPlays.Where( x => x.RadioStation == 1 && x.SongName.Contains( "Eric Clapton" ) ).Aggregate( new TimeSpan( 0 ), ( timeSpan, songPlay ) => timeSpan.Add( songPlay.TimeSpan ) );
        }
        private static SongPlay GetSongPlay( string arg )
        {
            var match = LineMatch.Match( arg );
            return new SongPlay
            {
                RadioStation = Convert.ToInt32( match.Groups[ 1 ].Value ),
                SongName = match.Groups[ 4 ].Value,
                TimeSpan = new TimeSpan( 0, Convert.ToInt32( match.Groups[ 2 ].Value ), Convert.ToInt32( match.Groups[ 3 ].Value ) )
            };
        }
    }
    public class SongPlay
    {
        public int RadioStation { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public string SongName { get; set; }
    }
