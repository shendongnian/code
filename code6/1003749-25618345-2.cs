    public class VideoProcessor : IDisposable {
        private FileStream _videoFile = null;
        private VideoProcessor() {}
        //user specified FileStream
        public VideoProcessor(FileStream fs) {_videoFile = fs;}
    
        public void Dispose() {
            _videoFile.Dispose(); //Dispose user passed FileStream
        }   
    }
