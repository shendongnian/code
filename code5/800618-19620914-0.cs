        public class ViewModelWrappers
        {
            static MemberViewModel _memberViewModel;
            public static MemberViewModel MemberViewModel
            {
                get
                {
                    if (_memberViewModel == null)
                        _memberViewModel = new MemberViewModel(Application.Current.Resources["UserName"].ToString());
    
                    return _memberViewModel;
                }
            }
    ...
    }
