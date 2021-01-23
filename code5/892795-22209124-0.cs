    public class ViewModel: INotifyPropertyChanged
    {
        public TypeOne SelectedTypeOne
        {
            get { return m_SelectedTypeOne; }
            set
            {
                m_SelectedTypeOne = value;
                
                NotifyPropertyChanged("SelectedTypeOne");
                //foreach (TypeTwo typeTwo in ListTwo)
                //{
                //    if (typeTwo.NameTwo == value.NameOne)
                //   {
                //        SelectedTypeTwo = typeTwo;
                //    }
                //}
                //these kind of horrible for loops from 500 years ago are not needed in C#. Use proper LINQ:
                SelectedTypeTwo = ListTwo.FirstOrDefault(x => x.NameTwo == value.NameOne);
            }
        }
        TypeTwo m_SelectedTypeTwo;
        public TypeTwo SelectedTypeTwo
        {
            get { return m_SelectedTypeTwo; }
            set
            {
                m_SelectedTypeTwo = value;
                NotifyPropertyChanged("SelectedTypeTwo");
            }
        }
    }
