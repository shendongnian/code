    public class MainVm : DependencyObject
    {
        /// <summary>
        /// Gets or sets a bindable value that indicates ComboBox SelectedItem
        /// </summary>
        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(MainVm),
            new PropertyMetadata(null, (d, e) =>
            {
                //property changed callback
                var vm = (MainVm)d;
                var val = (object)e.NewValue;
                if(val!=null && !vm.IsLastItemSelected )
                    //Result =  SelectedItem,   if the last item is not selected
                    vm.Result = val.ToString();
            }));
        /// <summary>
        /// Gets or sets a bindable value that indicates custom Text
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MainVm), new PropertyMetadata("", (d, e) =>
            {
                //property changed callback
                var vm = (MainVm)d;
                var val = (string)e.NewValue;
                //Result =  Text,           if last item is selected
                //          SelectedItem,   otherwise
                vm.Result = vm.IsLastItemSelected ? val : vm.SelectedItem.ToString();
            }));
        /// <summary>
        /// Gets or sets a bindable value that indicates whether the LastItem of ComboBox is Selected
        /// </summary>
        public bool IsLastItemSelected
        {
            get { return (bool)GetValue(IsLastItemSelectedProperty); }
            set { SetValue(IsLastItemSelectedProperty, value); }
        }
        public static readonly DependencyProperty IsLastItemSelectedProperty =
            DependencyProperty.Register("IsLastItemSelected", typeof(bool), typeof(MainVm),
            new PropertyMetadata(false, (d, e) =>
            {
                //property changed callback
                var vm = (MainVm)d;
                var val = (bool)e.NewValue;
                //Result =  Text,           if last item is selected
                //          SelectedItem,   otherwise
                vm.Result = val ? vm.Text : vm.SelectedItem.ToString();
            }));
        /// <summary>
        /// Gets or sets a bindable value that indicates Result
        /// </summary>
        public string Result
        {
            get { return (string)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }
        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register("Result", typeof(string), typeof(MainVm), new PropertyMetadata("select something..."));
    }
