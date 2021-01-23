    using Klaim.Interfaces;
    using Xamarin.Forms;
    
    namespace Klaim.Interfaces
    {
        public interface IImageResizer
        {
            byte[] ResizeImage (byte[] imageData, float width, float height);
        }
    }
