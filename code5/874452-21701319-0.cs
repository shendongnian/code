                     TfsTeamProjectCollection _tpc = null;
                     using (var picker = new TeamProjectPicker(TeamProjectPickerMode.NoProject, false))
                     {
                         if (picker.ShowDialog() == DialogResult.OK)
                         {
                            _tpc = picker.SelectedTeamProjectCollection;
                         }
                         if (_tpc == null)
                         {
                             MessageBox.Show("Please select a team project.");
                             return;
                         }
                        var versionControl = (VersionControlServer)_tpc.GetService(typeof(VersionControlServer));
