    private void DoSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBox cb = (sender as ComboBox);
        if (cb.SelectedIndex > -1)
        {
            string s = (cb.SelectedValue as ComboBoxItem).Content as string; 
            if (s == " ")
            {
                cb.SelectedIndex = cb.GetLastIndex();
            }
        }
        cb.SetLastIndex(cb.SelectedIndex);
    }
    public static class Extensions
    {
        private static Dictionary<ComboBox, int> _lastIndex = new Dictionary<ComboBox, int>();
        public static int GetLastIndex(this ComboBox me)
        {
            return _lastIndex.ContainsKey(me) ? _lastIndex[me] : -1;
        }
        public static void SetLastIndex(this ComboBox me, int NewValue)
        {
            if (_lastIndex.ContainsKey(me))
                _lastIndex[me] = NewValue;
            else
                _lastIndex.Add(me,NewValue);
        }
    }
