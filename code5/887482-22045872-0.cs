    <ComboBox ItemsSource="{Binding Path=PrintQueues, Mode=OneWay}" DisplayMemberPath="Name" Width="200" SelectedItem="{Binding Path=SelectedPrinter, Mode=TwoWay}"></ComboBox>
    private System.Printing.PrintQueue selectedPrinter;
    public System.Printing.PrintQueue SelectedPrinter
    {
        get { return selectedPrinter; }
        set
        {
            selectedPrinter = value;
            NotifyPropertyChanged(() => SelectedPrinter);
        }
    }
