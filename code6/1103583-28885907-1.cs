    public class AudioPlayer
    {
              
        public float Volume 
        {
           get { return _volume;}
           set 
           {
               _volume = value;
               //Do other necessary things that must happen when volume is changed
               ModifyChannelVolume(_volume);
           }
        }
        private float _volume; //Never assign to this directly!
    }
