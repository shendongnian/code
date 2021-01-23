    public class ImageHelper
    {
        private readonly AdaptiveImageSettings settings;
        private readonly IImageSizerFactory factory;
        public ImageHelper(AdaptiveImageSettings settings, IImageSizerFactory factory) {
            this.settings = settings;
            this.factory = factory;
        }
    }
