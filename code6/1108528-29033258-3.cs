        public ReportViewModel()
        {
            countryReportsHierarchy = new ObservableCollection<CountryReportsHierarchy>(new[]{
            new CountryReportsHierarchy(IsesService){Name = CountryReportTitle}});
        }
      private ArticleTypesHierarchy _SelectedArticleTitle;
        public ArticleTypesHierarchy SelectedArticleTitle
        {
            get { return _SelectedArticleTitle; }
            set
            {
                _SelectedArticleTitle = value;
                OnPropertyChanged("SelectedArticleTitle");
            }
        }      
        private void ArticleCategoryTitleSelectionChangedCommandAction()
        {
            GetData(SelectedArticleTitle.Name)
        }
