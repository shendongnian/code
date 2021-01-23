    private const string ConstTfsServerUri = @"http://YourTfsAddress:8080/tfs/";
     #region Undo
        public async Task<bool> UndoPendingChangesAsync(string path)
        {
            return await Task.Run(() => UndoPendingChanges(path));
        }
        private bool UndoPendingChanges(string path)
        {
            using (var tfs = TeamFoundationServerFactory.GetServer(ConstTfsServerUri))
            {
                tfs.Authenticate();
                // Create a new workspace for the currently authenticated user.   
                int res = 0;
                try
                {
                    var workspaceInfo = Workstation.Current.GetLocalWorkspaceInfo(ConstDefaultFlowsTfsPath);
                    var server = new TfsTeamProjectCollection(workspaceInfo.ServerUri);
                    Workspace workspace = workspaceInfo.GetWorkspace(server);
                    res = workspace.Undo(path, RecursionType.Full);
                }
                catch (Exception ex)
                {
                    UIHelper.Instance.RunOnUiThread(() => MessageBox.Show(ex.Message));
                }
                return res == 1;//undo has been done succesfully
            }
        }
