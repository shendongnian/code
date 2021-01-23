        /// <summary>
        /// Right mouse click simulation (SHIFT+F10)
        /// </summary>
        /// <param name="container">Container in whish the click should occur.</param>
        private static void ShowContextMenu(this UIItemContainer container)
        {
            container.Keyboard.HoldKey(KeyboardInput.SpecialKeys.SHIFT);
            container.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.F10);
            container.Keyboard.LeaveKey(KeyboardInput.SpecialKeys.SHIFT);
        }
