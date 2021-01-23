    public class WhateverYouWantViewModel : INotifyPropertyChanged
    {
        private EmpDetailsModel _model;
        public EmpDetailsModel Model
        {
            get { return _model; }
            set
            {
                if (value != _model)
                {
                    _model = value;
                    RaisePropertyChanged("Model");
                }
            }
        }
        public void GetLastestEntries()
        {
            // put in here the code calling your service
        }
    }
