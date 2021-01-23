        public void NewDataSource()
        {
            var viewModel = _dspViewModelFactory.ResolveDataSourcePickerViewModel();
            var view = _dspFactory.ResolveDataSourcePicker(viewModel);
            var result = view.ShowDialog();
            if (result.HasValue)
            {
                viewModel.IsAccepted = result.Value;
            }
        }
