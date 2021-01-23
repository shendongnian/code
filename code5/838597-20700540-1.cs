    public class AnnuityContext : INotifyPropertyChanged
    {
            public event PropertyChangedEventHandler PropertyChanged;
            
            public void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            
            private IList<AnnuityPayment> m_AnnuityPayments = new List<AnnuityPayment>();
            public IEnumerable<AnnuityPayment> AnnuityPayments
            {
                get
                {
                    return m_AnnuityPayments;
                }
            }
            
            private CalculationFormulaBase m_CalculationFormula;
            public CalculationFormulaBase CalculationFormula
            {
                get { return m_CalculationFormula; }
                set
                {
                    if (m_CalculationFormula != value)
                    {
                        m_CalculationFormula = value;
                        
                        EmptyAnnuityPayments();
                    }
                }
            }
           
          //...
       }
