        public interface IFile<T>
        {
            void Open(T path);
        }
    
        public abstract class Application
        {
            //public abstract void Open();
        }
    
    
        public class TextViewer : Application, IFile<TextFile>
        {
            public void Open(TextFile path)
            {
                //open textfile....
            }
        }
    
        public class MediaPlayer : Application, IFile<MediaFile>
        {     
            public void Open(MediaFile path)
            {
                //open media file...
            }
        }
    
        public class ImageViewer : Application, IFile<ImageFile>
        {
            public void Open(ImageFile path)
            {
                //open imagefile....
            }
        }
