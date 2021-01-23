    public class MyMemoryStream : MemoryStream
    {
        public bool CanDispose { get; set; }
    
        public override void Close()
        {
            if (!CanDispose)
            {
                return;
            }
    
            base.Close();
        }
    }
