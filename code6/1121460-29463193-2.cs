        protected override void Initialize()
        {
            //// Create the command for the menu item.
            var aCommand = new CommandID(GuidList.GuidCmdSet, (int)PkgCmdIdList.CmdId);
            var menuItemEnable = new OleMenuCommand((s, e) => createProjectsFromTemplates(), aCommand);
        }
