        public static void RaiseSelectionChanged(ComboBox cbx)
        {
            int index = cbx.SelectedIndex;
            cbx.SelectedIndex = -1;
            cbx.SelectedIndex = index;
        }
