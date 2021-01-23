    class ObjectRecorder
    {
        static List<ObjectRecorder> valuse=new List<ObjectRecorder>();
        bool record = false;
        public ObjectRecorder()
        {
            //your code
            if (record){ valuse.Add(this); }
        }
        public void StartRecording(){ record = true; }
        public void StopRecording(){ record = false; }
        public void ResetRecording()
        {
            valuse = new List<ObjectRecorder>();
        }
        public List<ObjectRecorder> GetAll()
        {
            return valuse;
        }
    }
