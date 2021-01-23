    // NOTE: I would prefer to simply call this Speaker, and call
    // Speaker 'WiredSpeaker' instead--but to leave your concrete class
    // names as they were in your original code, I've chosen to call this
    // SpeakerBase.
    public abstract class SpeakerBase
    {
        protected SpeakerBase() { }
        public void Beep()
        {
            if (CanBeep())
            {
                Console.WriteLine("Beep.");
            }
        }
        public abstract bool CanBeep();
    }
