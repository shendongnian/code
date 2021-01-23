    public class ViewManager
    {
        #region Singleton
        private ViewManager()
        {
        }
        static ViewManager _viewManager = null;
        public static ViewManager Instance
        {
            get
            {
                if (_viewManager == null)
                {
                    _viewManager = new ViewManager();
                }
                return _viewManager;
            }
        }
        #endregion
        public async Task LaunchView()
        {
            bool displaySubheader = false;
            var displayBackbutton = false;
            var arguments = ApplicationData.Current.LocalSettings.Values[Constants.APP_PARAMETERS] as string;
            var argumentsExist = !string.IsNullOrEmpty(arguments);
            if (!argumentsExist)
            {
                await UIServices.Instance.Load(typeof(HomePage), null, displaySubheader, displayBackbutton);
            }
            else
            {
                displaySubheader = true;
                displayBackbutton = false;
                await UIServices.Instance.Load(typeof(GroupPage), arguments, displaySubheader, displayBackbutton);
                var groupId = new Guid(arguments);
                await ReadPost(groupId);
            }
        }
