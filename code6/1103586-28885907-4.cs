    public class AudioPlayer
    {
              
        public float Volume 
        {
           get { return _volume_NeverSetThisDirectly;}
           set 
           {
               _volume = value;
               //Do other necessary things that must happen when volume is changed
               ModifyChannelVolume(_volume_NeverSetThisDirectly);
           }
        }
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        private float _volume_NeverSetThisDirectly; //Never assign to this directly!
    }
