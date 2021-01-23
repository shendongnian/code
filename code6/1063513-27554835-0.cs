        private void UpdateButtons()
        {
            #region btnOpenPath
            if (Directory.Exists(GamePath))
            {
                btnOpenPath.Enabled = true;
            }
            else
            {
                btnOpenPath.Enabled = false;
            }
            #endregion
            #region btnInstallUninstall
            if (InstalledProfile == null)
            {
                btnInstallUninstall.Text = "Install";
            }
            else
            {
                btnInstallUninstall.Text = "Uninstall";
            }
            if (Directory.Exists(GamePath) && lvFiles.CheckedItems.Count > 0)
            {
                btnInstallUninstall.Enabled = true;
            }
            else
            {
                btnInstallUninstall.Enabled = false;
            }
            #endregion
            #region btnDelete, btnCheckAll, btnUncheckAll
            if (InstalledProfile == null)
            {
                btnDelete.Enabled = true;
                btnCheckAll.Enabled = true;
                btnUncheckAll.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnCheckAll.Enabled = false;
                btnUncheckAll.Enabled = false;
            }
            #endregion
        }
