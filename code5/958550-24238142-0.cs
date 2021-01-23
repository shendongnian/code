        public override void UpButton()
        {
            if (Value == Maximum)
                Value = Minimum;
            else
                base.UpButton();
        }
        public override void DownButton()
        {
            if (Value == Minimum)
                Value = Maximum;
            else
                base.DownButton();
        }
