      <ScrollViewer ScrollViewer.VerticalScrollBarVisibility="Auto">
        <DataGrid ItemsSource="{Binding PresentableInventoryItems}" VerticalAlignment="Stretch" AutoGenerateColumns="False" Height="500">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="Produkttitel" Width="350" Binding="{ Binding ProductTitle}"/>
                    <DataGridTextColumn Header="Sku" Width="100" Binding="{ Binding Sku}" />
                    <DataGridTextColumn Header="Menge" Width="60"  Binding="{ Binding Quantity}" />
                </DataGrid.Columns>    
                </DataGrid>
    </ScrollViewer>
