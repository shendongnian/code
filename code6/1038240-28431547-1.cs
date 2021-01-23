        /// <summary>
        /// Get the context menu (right mouse menu) of <paramref name="container"/> whre the current focus is.
        /// </summary>
        /// <param name="mainWindow">Main window of the application, because the context menu is always a child of the window.</param>
        /// <param name="container">Container on which the right click shoul occur.</param>
        /// <returns>Context menu</returns>
        internal static PopUpMenu GetContextMenuOf(this Window mainWindow, UIItemContainer container)
        {
            using (CoreAppXmlConfiguration.Instance.ApplyTemporarySetting(c => c.PopupTimeout = 750))
            {
                container.ShowContextMenu();
                return mainWindow.Popup;
            }
        }
