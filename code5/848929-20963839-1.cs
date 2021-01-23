    [ValidationProperty("Value")]
    public class CustomDate : DateSelector 
    {
        protected override void OnInit(EventArgs e) { ... } // See above
        /// <summary>
        /// Gets the value of the date field
        /// </summary>
        public new string Value
        {
            get
            {
                if (month.SelectedIndex > 0 && day.SelectedIndex > 0 && year.SelectedIndex > 0)
                    return DateUtil.ToIsoDate(new DateTime(DateUtil.IsoDateToDateTime(StartDate).Year + year.SelectedIndex, month.SelectedIndex + 1, day.SelectedIndex + 1).Date);
                return String.Empty;
            }
        }
        /// <summary>
        /// Retuns the new result
        /// </summary>
        public override ControlResult Result
        {
            get
            {
                return new ControlResult(base.ControlName, Value, null);
            }
        }
    }
