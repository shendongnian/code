    class ViewModel:INotifyPropertyChanged
    {
     private DefineAddinModel model;
    
        public string URL
        {
            get { return model.URL;  }
            set
            {
                if (value != model.URL)
                {
                    model.url = value;
                    OnPropertyChanged("URL");
                }
            }
        }
    
        public string TemplateType
        {
            get { return model.TemplateType;  }
            set
            {
                if (value != model.TemplateType)
                {
                    model.TemplateType = value;
                    OnPropertyChanged("TemplateType");
                }
            }
        }
