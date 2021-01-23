        [Browsable(false)]
        [Category("Appearance")]
        [ReadOnly(true)]
        public bool IsPressed
        {
            get { return (bool)base.GetValue(ButtonBase.IsPressedProperty); }
            protected set {  base.SetValue(ButtonBase.IsPressedPropertyKey, BooleanBoxes.Box(value)); }
        }
