    class SubViewModel
    {
        public decimal PropertyA { get; set; }
        public decimal PropertyB { get; set; }
    }
    class ViewModel
    {
        public SubViewModel SubViewModel { get; set; }
    
        public void CalculateAandB()
        {
            SubViewModel.PropertyA = 12m;
            SubViewModel.PropertyB = 14m;
        
            PropertyChanged(this, new PropertyChangedEventArgs("SubViewModel"));
        }
    }
    <TextBlock x:Name="A" Text="{Binding SubViewModel.PropertyA}" />
    <TextBlock x:Name="B" Text="{Binding SubViewModel.PropertyB}" />
