    public class Person : DependencyObject
    {
        public static readonly DependencyProperty IsOtherSelectedProperty =
            DependencyProperty.Register("IsOtherSelected", typeof(bool), typeof(Person));
        public static readonly DependencyProperty ComboBoxTextProperty =
            DependencyProperty.Register("ComboBoxText", typeof(string), typeof(Person),
            new PropertyMetadata(OnComboBoxTextChanged));
        public static readonly DependencyProperty TextBoxTextProperty =
            DependencyProperty.Register("TextBoxText", typeof(string), typeof(Person),
            new PropertyMetadata(OnTextBoxTextChanged));
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(Person));
        public bool IsOtherSelected
        {
            get { return (bool)GetValue(IsOtherSelectedProperty); }
            set { SetValue(IsOtherSelectedProperty, value); }
        }
        public string ComboBoxText
        {
            get { return (string)GetValue(ComboBoxTextProperty); }
            set { SetValue(ComboBoxTextProperty, value); }
        }
        public string TextBoxText
        {
            get { return (string)GetValue(TextBoxTextProperty); }
            set { SetValue(TextBoxTextProperty, value); }
        }
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            private set { SetValue(NameProperty, value); }
        }
        private static void OnComboBoxTextChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Person person = (Person)d;
            string value = (string)e.NewValue;
                person.Name = person.IsOtherSelected ? person.TextBoxText : value;
        }
        private static void OnTextBoxTextChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Person person = (Person)d;
            string value = (string)e.NewValue;
                person.Name = person.IsOtherSelected ? value : person.ComboBoxText;
        }
    }
