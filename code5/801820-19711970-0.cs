        /// <summary>
        /// Writes out the history of changes to a file.
        /// </summary>
        /// <param name="path">The path to a file similar to $/FabrikamFiber/Main/FabrikamFiber.CallCenter/FabrikamFiber.CallCenter.sln</param>
        private static void _GetHistory(string path)
        {
            using (TeamProjectPicker tpp = new TeamProjectPicker(TeamProjectPickerMode.SingleProject, false, new UICredentialsProvider()))
            {
                if (tpp.ShowDialog() == DialogResult.OK)
                {
                    TfsTeamProjectCollection projectCollection = tpp.SelectedTeamProjectCollection;
                    VersionControlServer server = projectCollection.GetService<VersionControlServer>();
                    Item item = server.GetItem(path);
                    int changeId = item.DeletionId != 0 ? item.ChangesetId - 1 : item.ChangesetId;
                    ChangesetVersionSpec versionCurrent = new ChangesetVersionSpec(changeId);
                    ChangesetVersionSpec versionFrom = new ChangesetVersionSpec(1);
                    IEnumerable changesets = server.QueryHistory(path, versionCurrent, 0, RecursionType.None, null, versionFrom, LatestVersionSpec.Latest, int.MaxValue, true, false);
                    foreach(Changeset changeset in changesets)
                    {
                        Item info = changeset.Changes[0].Item;
                        Console.WriteLine(string.Format("ItemId {0} ServerItem {1}", info.ItemId, info.ServerItem));                        
                    }                    
                }
            }
        }
