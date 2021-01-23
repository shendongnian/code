        static void ShowViewModel<T>(object parameter) where T : IMvxViewModel
        {
            var viewDispatcher = Mvx.Resolve<IMvxViewDispatcher>();
            var request = MvxViewModelRequest.GetDefaultRequest(typeof(T));
            request.ParameterValues = ((object)parameter).ToSimplePropertyDictionary();
            viewDispatcher.ShowViewModel(request);
        }
