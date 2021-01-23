    public class Speaker
    {
        public bool IsPlugged { get; set; }
        public virtual void Beep()
        {
            if (!IsPlugged)
            {
                throw
                new InvalidOperationException("Speaker is not plugged in!");
            }
            Console.WriteLine("Beep.");
        }
    }
    public class WirelessSpeaker : Speaker
    {
        public bool TransmitterIsOn { get; set }
        
        public override void Beep()
        {
            if (!TransmitterIsOn)
            {
                throw
                new InvalidOperationException("Wireless Speaker transmitter is not on!");
            }
            Console.WriteLine("Beep.");
        }
    }
	public class IBeepSpeakers
    {
        private readonly Speaker _speaker;
        public IBeepSpeakers(Speaker speaker)
        {
            Contract.Requires(speaker != null);
            Contract.Ensures(_speaker != null && _speaker == speaker);
            _speaker = speaker;
            // Since we know we act on speakers, and since we know
            // a speaker needs to be plugged in to beep it, make sure
            // the speaker is plugged in.
            _speaker.IsPlugged = true;
        }
        pubic void BeepTheSpeaker()
        {
            _speaker.Beep();
        }
    }
    public static class MySpeakerConsoleApp
    {
        public static void Main(string[] args)
        {
            BeepWiredSpeaker();
            try
            {
                BeepWirelessSpeaker_Version1();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"ERROR: e.Message");
            }
			
			BeepWirelessSpeaker_Version2();
        }
        // We pass in an actual speaker object.
        // This method works as expected.
        public static BeepWiredSpeaker()
        {
            Speaker s = new Speaker();
            IBeepSpeakers wiredSpeakerBeeper = new IBeepSpeakers(s);
            wiredSpeakerBeeper.BeepTheSpeaker();
        }
        public static BeepWirelessSpeaker_Version1()
        {
            // This is a valid assignment.
            Speaker s = new WirelessSpeaker();
            IBeepSpeakers wirelessSpeakerBeeper = new IBeepSpeakers(s);
            // This call will fail!
            // In WirelessSpeaker, we _OVERRODE_ the Beep method to check
            // that TransmitterIsOn is true. But, IBeepSpeakers doesn't
            // know anything _specifically_ about WirelessSpeaker speakers,
            // so it can't set this property!
            // Therefore, an InvalidOperationException will be  thrown.
            wirelessSpeakerBeeper.BeepTheSpeaker();
        }
		
		public static BeepWirelessSpeaker_Version2()
		{
		    Speaker s = new WirelessSpeaker();
			// I'm using a cast, to show here that IBeepSpeakers is really
			// operating on a Speaker object. But, this is one way we can
			// make IBeepSpeakers work, even though it thinks it's dealing
			// only with Speaker objects.
			//
			// Since we set TransmitterIsOn to true, the overridden
			// Beep method will now execute correctly.
			//
			// But, it should be clear that IBeepSpeakers cannot act on both
			// Speakers and WirelessSpeakers in _exactly_ the same way and
			// have confidence that an exception will not be thrown.
			((WirelessSpeaker)s).TransmitterIsOn = true;
			
			IBeepSpeakers wirelessSpeakerBeeper = new IBeepSpeaker(s);
			
			// Beep the speaker. This will work because TransmitterIsOn is true.
			wirelessSpeakerBeeper.BeepTheSpeaker();
    }
