        /// <summary>
        /// Switches the focus to the next when control on tab key pressed.
        /// </summary>
        /// <param name="gridControl">GridView's grid control</param>
        public static void ApplyTabStopBehavior(this GridControl gridControl)
        {
            gridControl.ProcessGridKey += (sender, e) =>
            {
                var gridView = gridControl.FocusedView as GridView;
                if (gridView != null && e.KeyCode == Keys.Tab)
                {
                    ProcessTabKey(gridView, e);
                }
            };
        }
