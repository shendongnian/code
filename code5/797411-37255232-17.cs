     public class MainFeedViewModel : BaseViewModel//, IDataErrorInfo
        {
            private ObservableCollection<FeedItemViewModel> _feedItems;
            [XmlIgnore]
            public ObservableCollection<FeedItemViewModel> FeedItems
            {
                get
                {
                    return _feedItems;
                }
                set
                {
                    _feedItems = value;
                    OnPropertyChanged("FeedItems");
                }
            }
            [XmlIgnore]
            public ObservableCollection<FeedItemViewModel> FilteredFeedItems
            {
                get
                {
                    if (SearchText == null) return _feedItems;
    
                    return new ObservableCollection<FeedItemViewModel>(_feedItems.Where(x => x.Title.ToUpper().Contains(SearchText.ToUpper())));
                }
            }
    
            private string _title;
            [Required]
            [StringLength(20)]
            //[CustomNameValidationRegularExpression(5, 20)]
            [CustomNameValidationAttribute(3, 20)]
            public string Title
            {
                get { return _title; }
                set
                {
                    _title = value;
                    OnPropertyChanged("Title");
                }
            }
            private string _url;
            [Required]
            [StringLength(200)]
            [Url]
            //[CustomValidation(typeof(MainFeedViewModel), "UrlValidation")]
            /// <summary>
            /// Validation of URL should be with custom method like the one that implemented below, or with 
            /// </summary>
            public string Url
            {
                get { return _url; }
                set
                {
                    _url = value;
                    OnPropertyChanged("Url");
                }
            }
    
            public MainFeedViewModel(string url, string title)
            {
                Title = title;
                Url = url;
            }
            /// <summary>
            /// 
            /// </summary>
            public MainFeedViewModel()
            {
    
            }
            public MainFeedViewModel(ObservableCollection<FeedItemViewModel> feeds)
            {
                _feedItems = feeds;
            }
    
    
            private string _searchText;
            [XmlIgnore]
            public string SearchText
            {
                get { return _searchText; }
                set
                {
                    _searchText = value;
    
                    OnPropertyChanged("SearchText");
                    OnPropertyChanged("FilteredFeedItems");
                }
            }
             
            #region Data validation local
            /// <summary>
            /// Custom URL validation method
            /// </summary>
            /// <param name="obj"></param>
            /// <param name="context"></param>
            /// <returns></returns>
            public static ValidationResult UrlValidation(object obj, ValidationContext context)
            {
                var vm = (MainFeedViewModel)context.ObjectInstance;
                if (!Uri.IsWellFormedUriString(vm.Url, UriKind.Absolute))
                {
                    return new ValidationResult("URL should be in valid format", new List<string> { "Url" });
                }
                return ValidationResult.Success;
            }
           
            #endregion
        }
