    public class MultiResImageChooser
    {
        public Uri BestResolutionImage
        {
            get
            {
                switch (ResolutionHelper.CurrentResolution)
                {
                    case Resolutions.HD:
                        return new Uri("/Assets/MyImage.screen-720p.jpg", UriKind.Relative);
                    case Resolutions.WXGA:
                        return new Uri("/Assets/MyImage.screen-wxga.jpg", UriKind.Relative);
                    case Resolutions.WVGA:
                        return new Uri("/Assets/MyImage.screen-wvga.jpg", UriKind.Relative);
                    default:
                        throw new InvalidOperationException("Unknown resolution type");
                }
            }
        }
    }
