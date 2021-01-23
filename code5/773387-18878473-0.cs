    public class MyDateTimeDialogFragment : DialogFragment
    {
        public event EventHandler DateChanged;
        public DateTime Date { get; private set; }
        private readonly int _year;
        private readonly int _day;
        private readonly int _month;
        public MyDateTimeDialogFragment(int year, int month, int day)
        {
            _year = year;
            _month = month;
            _day = day;
        }
        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var dialog = new DatePickerDialog(Activity, CallBack, _year, _month, _day);
            return dialog;
        }
        private void CallBack(object sender, DatePickerDialog.DateSetEventArgs dateSetEventArgs)
        {
            Date = dateSetEventArgs.Date;
            if (DateChanged != null)
                DateChanged(this, EventArgs.Empty);
        }
    }
