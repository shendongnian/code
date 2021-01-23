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
    private void SetSelectedFruit_Mediator(object args)
    {
        string selectedFruit = (string)args;
        DataDetailsModel.SelectedFruit = selectedFruit;
    }
    public DataDetailsViewModel() 
    {
        DataDetailsModel = new DataDetailsModel();
        Mediator.Register("ShowDetails", ShowDetails_Mediator);
        Mediator.Register("SetSelectedFruit", SetSelectedFruit_Mediator);
    }
