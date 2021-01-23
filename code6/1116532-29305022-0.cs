    public IMvxCommand FocusChange
    {
        get
        {
            return new MvxCommand<EditText.FocusChangeEventArgs>(e => OnFocusChange(e));
        }
    }
    private void OnFocusChange(EditText.FocusChangeEventArgs e)
    {
        if (!e.HasFocus)
        {
             //Do Something
        }
    }
