    public void clickeditem(ItemClickEventArgs Args)
    {
        SetFunctionFieldValue(Args.ClickedItem.ToString());
    }
    private void SetFunctionFieldValue(string text)
    {
        function = text;
    }
