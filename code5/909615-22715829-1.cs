    public IList<YourType> FirstItemsSource
    {
        get
        {
            return this.firstItemsSource;
        }
        set
        {
            this.firstItemsSource = value;
        }
    }
    public YourType SecondSelectedValue
    {
        get
        {
            return this.secondSelectedValue;
        }
        set
        {
            this.secondSelectedValue = value;
            // here you can set the FirstItemsSource
            this.FirstItemsSource = this.RefreshFirstItemsSource();
        }
    }
