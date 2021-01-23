DataDetailsModel
    public class DataDetailsModel : NotificationObject
    {
        #region SelectedFruit
        private string _selectedFruit = "";
        public string SelectedFruit
        {
            get
            {
                return _selectedFruit;
            }
            set
            {
                _selectedFruit = value;
                NotifyPropertyChanged("SelectedFruit");
            }
        }
        #endregion
        #region IsVisible
        private bool _isVisible = false;
        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                NotifyPropertyChanged("IsVisible");
            }
        }
        #endregion
    }
ListOfDataModel
    public class ListOfDataModel : NotificationObject
    {
        #region FruitGreen
        private string _fruitGreen = "Apple";
        public string FruitGreen
        {
            get
            {
                return _fruitGreen;
            }
            set
            {
                _fruitGreen = value;
                NotifyPropertyChanged("FruitGreen");
            }
        }
        #endregion
        #region FruitYellow
        private string _fruitYellow = "Limon";
        public string FruitYellow
        {
            get
            {
                return _fruitYellow;
            }
            set
            {
                _fruitYellow = value;
                NotifyPropertyChanged("FruitYellow");
            }
        }
        #endregion
    }
