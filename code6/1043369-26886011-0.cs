    public class ManageStatus
    {
        private string _state;
        private double _up,_down,_process;
    
        public string State
        {
            get{ return _state;}
            set{ _state=value;}
        }
        public string State
        {
            get{ return _state;}
            set{ _state=value;}
        }
        public double Up
        {
            get{ return _up;}
            set{ _up=value;}
        }
        public double Down
        {
            get{ return _down;}
            set{ _down=value;}
        }
        public double Process
        {
            get{ return _process;}
            set{ _process=value;}
        }
        public void GetState()
        {
            while (true)
            {
                if (handle == null)
                {
                    Thread.Sleep(1000);
                    continue;
                }
                var status = handle.GetStatus();
                if (status.IsSeeding)
                {
                    break;
                }                
                _state = status.State.ToString();
                _up = status.UploadRate;
                _down = status.DownloadRate;
                _process = status.Progress;
                Thread.Sleep(1000);
             }  
        }
    }
