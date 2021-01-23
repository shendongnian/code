        public void SelectFolder(string path)
        {
            dte.ExecuteCommand("View.TfsSourceControlExplorer");
            Microsoft.VisualStudio.TeamFoundation.VersionControl.VersionControlExplorerExt explorer =
                GetSourceControlExplorer();
            if (explorer != null)
                explorer.Navigate(path);
        }
        private Microsoft.VisualStudio.TeamFoundation.VersionControl.VersionControlExplorerExt GetSourceControlExplorer()
        {
            Microsoft.VisualStudio.TeamFoundation.VersionControl.VersionControlExt versionControl =
                dte.GetObject("Microsoft.VisualStudio.TeamFoundation.VersionControl.VersionControlExt") as
                    Microsoft.VisualStudio.TeamFoundation.VersionControl.VersionControlExt;
            if (versionControl == null)
                return null;
            return versionControl.Explorer;
        }
