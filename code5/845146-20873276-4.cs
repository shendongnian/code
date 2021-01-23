DataDetailsViewModel
    public class DataDetailsViewModel
    {
        #region DataDetailsModel
        private DataDetailsModel _dataDetailsModel = null;
        public DataDetailsModel DataDetailsModel
        {
            get
            {
                return _dataDetailsModel;
            }
            set
            {
                _dataDetailsModel = value;
            }
        }
        #endregion
        #region ShowDetails_Mediator
        private void ShowDetails_Mediator(object args)
        {
            bool showDetails = (bool)args;
            if (showDetails == true)
            {
                DataDetailsModel.IsVisible = true;
            }
            else
            {
                DataDetailsModel.IsVisible = false;
            }
        }
        #endregion
        #region SetSelectedFruit_Mediator
        private void SetSelectedFruit_Mediator(object args)
        {
            string selectedFruit = (string)args;
            DataDetailsModel.SelectedFruit = selectedFruit;
        }
        #endregion
        #region DataDetailsViewModel Constructor
        public DataDetailsViewModel() 
        {
            DataDetailsModel = new DataDetailsModel();
            Mediator.Register("ShowDetails", ShowDetails_Mediator);
            Mediator.Register("SetSelectedFruit", SetSelectedFruit_Mediator);
        }
        #endregion
    }
ListOfDataViewModel
    public class ListOfDataViewModel
    {
        #region ListOfDataModel
        private ListOfDataModel _listOfDataModel = null;
        public ListOfDataModel ListOfDataModel
        {
            get
            {
                return _listOfDataModel;
            }
            set
            {
                _listOfDataModel = value;
            }
        }
        #endregion
        #region GreenButtonCommand
        private ICommand _greenButtonCommand = null;
        public ICommand GreenButtonCommand
        {
            get
            {
                if (_greenButtonCommand == null)
                {
                    _greenButtonCommand = new RelayCommand(param => this.GreenButton(), null);
                }
                return _greenButtonCommand;
            }
        }
        private void GreenButton()
        {
            Mediator.NotifyColleagues("ShowDetails", true);
            Mediator.NotifyColleagues("SetSelectedFruit", ListOfDataModel.FruitGreen);
        }
        #endregion
        #region YellowButtonCommand
        private ICommand _yellowButtonCommand = null;
        public ICommand YellowButtonCommand
        {
            get
            {
                if (_yellowButtonCommand == null)
                {
                    _yellowButtonCommand = new RelayCommand(param => this.YellowButton(), null);
                }
                return _yellowButtonCommand;
            }
        }
        private void YellowButton()
        {
            Mediator.NotifyColleagues("ShowDetails", true);
            Mediator.NotifyColleagues("SetSelectedFruit", ListOfDataModel.FruitYellow);
        }
        #endregion
        #region ListOfDataViewModel Constructor
        public ListOfDataViewModel() 
        {
            ListOfDataModel = new ListOfDataModel();
        }
        #endregion
    }
