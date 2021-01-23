    public class IBeepSpeakers
    {
        private readonly SpeakerBase _speaker;
        private readonly Action<SpeakerBase> _enableBeeping;
        public IBeepSpeakers(SpeakerBase speaker, Action<SpeakerBase> enableBeeping)
        {
            Contract.Requires(speaker != null);
            Contract.Requires(enableBeeping != null);
            Contract.Ensures(
                _speaker != null && 
                _speaker == speaker);
            Contract.Ensures(
                _enableBeeping != null && 
                _enableBeeping == enableBeeping);
            _speaker = speaker;
            _enableBeeping = enableBeeping;
        }
        pubic void BeepTheSpeaker()
        {
            if (!_speaker.CanBeep())
            {
               _enableBeeping(_speaker);
            }
            _speaker.Beep();
        }
    }
    public static class MySpeakerConsoleApp
    {
        public static void Main(string[] args)
        {
            BeepWiredSpeaker();
            // No more try...catch needed. This can't possibly fail!
            BeepWirelessSpeaker();
        }
        public static BeepWiredSpeaker()
        {
            Speaker s = new Speaker();
            IBeepSpeakers wiredSpeakerBeeper =
                new IBeepSpeakers(s, s => ((Speaker)s).IsPlugged = true);
            wiredSpeakerBeeper.BeepTheSpeaker();
        }
        public static BeepWirelessSpeaker()
        {
            WirelessSpeaker w = new WirelessSpeaker();
            IBeepSpeakers wirelessSpeakerBeeper =
                new IBeepSpeakers(w, s => ((WiredSpeaker)s).IsTransmitterOn = true);
            wirelessSpeakerBeeper.BeepTheSpeaker();
        }
    }
