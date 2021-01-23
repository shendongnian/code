    public class ThingMyPropertyTargetBinding : MvxAndroidTargetBinding
    {
        protected Thing Thing
        {
            get { return (Thing) Target; }
        }
        public ThingMyPropertyTargetBinding (Thing target) : base(target)
        {
        }
        public override void SubscribeToEvents()
        {
            Thing.MyPropertyChanged += TargetOnMyPropertyChanged;
        }
        private void TargetOnMyPropertyChanged(object sender, SpecialEventArgs eventArgs)
        {
            var target = Target as Thing;
            if (target == null)
                return;
            var value = target.GetMyProperty();
            FireValueChanged(value);
        }
        protected override void SetValueImpl(object target, object value)
        {
            var binaryEdit = (Thing)target;
            binaryEdit.SetMyProperty((PType)value);
        }
        public override Type TargetType
        {
            get { return typeof(PType); }
        }
        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.TwoWay; }
        }
        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                var target = Target as BinaryEdit;
                if (target != null)
                {
                    target.MyPropertyChanged -= TargetOnMyPropertyChanged;
                }
            }
            base.Dispose(isDisposing);
        }
    }
