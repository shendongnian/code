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
