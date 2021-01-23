    public class Plugin
        : IMvxPlugin          
    {
        public void Load()
        {
            Mvx.RegisterType<IMvxFileStore, MvxTouchFileStore>();
        }
    }
