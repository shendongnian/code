    <ComboBox HorizontalAlignment="Left"
              Margin="125,110,0,0"
              VerticalAlignment="Top"
              Width="120"
              DisplayMemberPath="lot_number"
              SelectedItem="{Binding SelectedLot}"
              ItemsSource="{Binding LotNumList}"
              RenderTransformOrigin="0.583,2" Height="18" />
         private LotInformation selectedLot;
        public LotInformation SelectedLot
        {
            get { return selectedLot; }
            set
            {
                selectedLot = value;
                var lot = value as LotInformation;
                if (lot != null)
                {
                    ComponentsList = new List<Components>();
                    foreach(Components comp in lot.Components)
                    {
                        ComponentsList.Add(comp);
                    }
                }
            }
        }
