    class OptionsViewModel
    {
        OptionValue<OptionsViewModel>[] Options;
        public OptionsViewModel()
        {
            Options = new OptionValue<OptionsViewModel>[]
            {
                OptionValue<OptionsViewModel>.Create(this, 0, OptionSource.SysParameter, "SingleSelection"),
                OptionValue<OptionsViewModel>.Create(this, 0.002, OptionSource.ConfigFileProperty, "Tolerance"),
            };
        }
        public int SingleSelection { get; set; }
        public double Tolerance { get; set; }
        public void Init()
        {
            foreach (OptionValue<OptionsViewModel> option in Options)
            {
                FetchValueFromOptionSourceAndSetToProperty(option);
            }
        }
        // Signature and implementation modified a bit just for illustration purposes.
        public string Save()
        {
            StringBuilder sb = new StringBuilder();
            foreach (OptionValue<OptionsViewModel> option in Options)
            {
                sb.AppendLine(StoreValueFromPropertyToOptionSource(option));
            }
            return sb.ToString();
        }
        private void FetchValueFromOptionSourceAndSetToProperty(OptionValue<OptionsViewModel> option)
        {
            // Obviously, some actual code that would retrieve values would
            // go here for a real program.
            switch (option.OptionName + "Selector")
            {
                case "SingleSelectionSelector":
                    option.SetValue(17);
                    break;
                case "ToleranceSelector":
                    option.SetValueFromText("3.141592");
                    break;
            }
        }
        private string StoreValueFromPropertyToOptionSource(OptionValue<OptionsViewModel> option)
        {
            // Likewise, in your actual code you wouldn't even return
            // anything here, and the code would actually store the value
            // to some appropriate location.
            return option.GetValue().ToString();
        }
    }
