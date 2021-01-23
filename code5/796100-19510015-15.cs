    public class ViewModel : ViewModelBase
    {
        public String Prop1
        {
            get { return GetValue(() => Prop1); }
            set { SetValue(() => Prop1, value); }
        }
        public bool Bool1
        {
            get { return GetValue(() => Bool1); }
            set { SetValue(() => Bool1, value); }
        }
