        private void RemoveMenuItems(MenuStrip menuStrip1) {
            foreach (object menuItem in menuStrip1.Items) {
                RemoveToolStripItems(menuItem as ToolStripItem, false);
            }
        }
        /// <summary>
        /// Checks to see if the ToolStripItem that is passed to it has a tag type of {submodule},
        /// if it does then hide all of the children (if applicable). If all children are hidden, hide current.
        /// </summary>
        private bool RemoveToolStripItems(ToolStripItem toolStripItem, bool forceHide) {
            if (toolStripItem == null) { return false; }
            ToolStripMenuItem menuItem = toolStripItem as ToolStripMenuItem;
            bool hideCurrent = forceHide || ((toolStripItem.Tag as submodule) != null);
            if (menuItem != null && menuItem.HasDropDownItems) {
                bool allChildrenAreHidden = true;
                foreach (object dropDownItem in menuItem.DropDownItems) {
                    allChildrenAreHidden &= RemoveToolStripItems(dropDownItem as ToolStripItem, hideCurrent);
                }
                hideCurrent |= allChildrenAreHidden;
            }
            toolStripItem.Available = !hideCurrent ;
            return hideCurrent;
        }
