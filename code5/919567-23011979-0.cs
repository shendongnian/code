    <toolkit:ListPicker Name="lstBoxBaseUnitOfMeasure" Width="100" Margin="0,4,0,0" SelectionChanged="listPicker_SelectionChanged">
         <toolkit:ListPicker.Items>
              <TextBlock Text="EACH" Height="30"/>
              <TextBlock Text="GRAM" Height="30"/>
         </toolkit:ListPicker.Items>
    </toolkit:ListPicker>
     private void listPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (lstBoxBaseUnitOfMeasure.SelectedItem != null)
                {
                    var texBlock = (TextBlock) lstBoxBaseUnitOfMeasure.SelectedItem;
                    selectedUnit = texBlock.Text;
                    TblProductsToOrder newProductToOrder = new TblProductsToOrder
                        {
                            OrderNId = selectedID,
                            Quantity = int.Parse(txtQuantity.Text),
                            BaseUnitOfMeasure = selectedUnit
                        };
                }
            }
        
