    interface IBitmapStreamProvider 
    {
        IEnumerable<Bitmap> FileQueue;
        bool SaveOutput(Bitmap filetosave);
    }
    
    public class BitmapStreamProvider : IBitmapStreamProvider
    {    
        public IEnumerable<Bitmap> FileQueue
        {
            get
            {
                return GetNextFile();
            }
        }
    
        private IEnumerable<Bitmap> GetNextFile ()
        {
            IEnumerable<string> fileLocations = // load list of file uri's or paths here, recursively if needed
            foreach (var location in fileLocations)
            {
                var bitmap = // fetch bitmap
                yield return bitmap;
            }
        }
    
        public bool SaveOutput(Bitmap filetosave)
        {
            // ...
        }
    }
