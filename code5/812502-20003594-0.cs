    public class TfsWrapper
    {
        private TfsTeamProjectCollection tpc = null;
        private VersionControlServer versionControl = null;
        public TfsWrapper(string server, ...)
        {
            try
            {
                Uri serverUri = new Uri(server + "/tfs");
                ICredentialsProvider credentials = new UICredentialsProvider();
                tpc = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(serverUri, credentials);
                tpc.EnsureAuthenticated();
                versionControl = tpc.GetService<VersionControlServer>();
            }
        }
        public void Checkout(string path)
        {
            Workspace workspace = versionControl.TryGetWorkspace(path);
            workspace.PendEdit(path);
        }
