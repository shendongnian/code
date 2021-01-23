    <DatePicker SelectedDateChanged="DatePicker_SelectedDateChanged" />
    ...
    private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
    {
        DateTime SelDate = (DateTime)e.AddedItems[0];
        DateTime SelDate2 = dtvencimento.SelectedDate.Value;
        if (SelDate > SelDate2) // put a break point here and check value of SelDate2 
        {
            MessageBox.Show("Data do Vencimento tem de ser maior que data inicial", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
