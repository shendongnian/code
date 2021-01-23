    public override async void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode,
        Dictionary<string, object> viewModelState)
    {
        _headerViewModel.PageTitle = "Invoice Details";
        await LoadPayees();
        if (navigationParameter is Invoice)
        {
            _isEditing = true;
            CurrentInvoice = navigationParameter as Invoice;
            var payee = await _payeesRepository.LoadByIdAsync(CurrentInvoice.PayeeId);
            SelectedPayee = payee;
            await LoadPayments();
        }
        else
        {
            CurrentInvoice = new Invoice
            {
                CreationDate = DateTime.Now,
                InvoiceDate = DateTime.Now,
                Frequency = "M"
            };
        }
        /* await LoadPayees(); was originally down here... oops! */
        base.OnNavigatedTo(navigationParameter, navigationMode, viewModelState);
    }
