    public interface IApplication
    {
        Type GetSupportedApplicationType();
        void OpenFile(IFile oFile);
    }
    public class MediaApplication : IApplication
    {
        #region IApplication Members
        public Type GetSupportedApplicationType()
        {
            return typeof(MediaFile);
        }
        public void OpenFile(IFile oFile)
        {
            // do the work
        }
        #endregion
    }
