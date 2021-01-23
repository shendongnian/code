	Carro sCar = new Carro();
	private void listCarros_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        ListBox listBox = sender as ListBox;
        if (listBox != null && listBox.SelectedItem != null)
        {
            sCar = (Carro)listBox.SelectedItem;
...
	private void btnEditCar_Click(object sender, EventArgs e)
	{
		sCar.ProperyYouWantToChange = "Stuff I want to change"
	}
