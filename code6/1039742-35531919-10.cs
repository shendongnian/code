    public class Speaker : SpeakerBase
    {
        public bool IsPlugged { get; set; }
        public override bool CanBeep() => IsPlugged;
    }
    public class WirelessSpeaker : SpeakerBase
    {
        public bool IsTransmiterOn { get; set; }
        public override bool CanBeep() => IsTransmitterOn;
    }
