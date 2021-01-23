        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsFormOkay { get { return IsValid(Items) && MyObject.IsParametersOkay; } }
        public bool IsValid(DependencyObject obj)
        {
            if (Validation.GetHasError(obj)) return false;
            for (int i = 0, n = VisualTreeHelper.GetChildrenCount(obj); i < n; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (!IsValid(child)) return false;
            }
            return true;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("IsFormOkay"));
        }
