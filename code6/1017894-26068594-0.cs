    class Message<T> where T : LoanEvent
    {
        public T LoanEvent { get; protected set; }
        public string Topic { get; protected set; }
    }
    class MessageSender
    {
        public void Send<T>(Message<T> message) where T : LoanEvent
        {
        }
    }
    abstract class MessageBuilder<T> : Message<T> where T : LoanEvent, new()
    {
        protected MessageBuilder(ILoans loans)
        {
            LoanEvent = new T
            {
                LoanNumber = loans.CurrentLoan.LoanNumber,
                LasedUsedByUser = loans.UserFullName
            };
        }
    }
    class LoanMajorEventMessageBuilder : MessageBuilder<LoanMajorEvent>
    {
        public LoanMajorEventMessageBuilder(ILoans loans, int majorEventNum)
            : base(loans)
        {
            LoanEvent.MajorEventNum = majorEventNum;
            Topic = string.Format("{0}.{1}", LoanEvent.GetType().Name, LoanEvent.MajorEventNum);
        }
    }
    class LoanFieldEventMessageBuilder : MessageBuilder<LoanFieldEvent>
    {
        public LoanFieldEventMessageBuilder(ILoans loans, LoanFieldEventArgs loanFieldEventArgs)
            : base(loans)
        {
            LoanEvent.OldValue = loanFieldEventArgs.OldValue.ToString();
            LoanEvent.NewValue = loanFieldEventArgs.NewValue.ToString();
            LoanEvent.FieldName = loanFieldEventArgs.LoanField.DataDefinition.XmlName;
            LoanEvent.FieldNumber = loanFieldEventArgs.LoanField.DataDefinition.FieldNumber;
            Topic = string.Format("{0}.{1}", LoanEvent.GetType().Name, LoanEvent.FieldNumber);
        }
    }
