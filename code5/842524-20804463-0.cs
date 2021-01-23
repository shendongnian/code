    Workspace workspace = tfServer.CreateWorkspace("TempDevWorkspace", tfServer.AuthorizedUser);
            string topDir = null;
            string localDir = @"c:\TempDevWorkspaceFolder";
            workspace.Map(tfsItem.VcDevFolder, localDir);
            workspace.Get();
            string directory = Path.Combine(workspace.Folders[0].LocalItem, null);
