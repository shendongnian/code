    public class QuestionTextViewModel : QuestionItemViewModel
    {
        private Timer Timer { get; set; }
        public QuestionTextViewModel(IEventAggregator eventAggregator, TransactionDetail transactionDetail)
            : base(transactionDetail)
        {
            _eventAggregator = eventAggregator;
            TransactionDetailId = transactionDetail.TransactionDetailId;
            this.Timer = new Timer(1500) {AutoReset = false};
            this.Timer.Elapsed += TextValueTimer_Elapsed;
        }
        public string TextValue
        {
            get { return _textValue; }
            set
            {
                _textValue = value;
                this.Timer.Stop();
                this.Timer.Start();
            }
        }
        private void TextValueTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            NotifyOfPropertyChange(() => TextValue);
        }
    }
