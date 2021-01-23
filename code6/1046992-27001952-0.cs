    [Serializable]
    public class MySerializableSettings
    {
        private bool atDefaults = false;
    
        [OnDeserializing]
        public void OnDeserializing( StreamingContext context )
        {
            atDefaults = true;
        }
        
        internal bool AtDefaults {
            get { return atDefaults; }
        }
    }
    
