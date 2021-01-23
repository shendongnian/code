    <ComboBox 
	DisplayMemberPath="DataContext.MySelectedItem.gdp_code" 
    Text="{Binding MySelectedItem.gdp_code}" 
    IsEditable="True">
    <ComboBox.Items>
        <ComboBoxItem>
            <ComboBoxItem.Template>
                <ControlTemplate>
                    <DataGrid SelectedItem={Binding MySelectedItem} ItemsSource="{Binding CodeGDP_Collection}"   AutoGenerateColumns="False">
                        <DataGrid.Columns>
                           <DataGridTextColumn Binding="{Binding gdp_code}" />
						   <DataGridTextColumn Binding="{Binding gdp_nom}" />
						   <DataGridTextColumn Binding="{x:Null}"/>
						   <DataGridTextColumn Binding="{Binding gdp_ville}" />
						   <DataGridTextColumn Binding="{Binding gdp_code_postal}"/>
                        </DataGrid.Columns>
                    </DataGrid>
                </ControlTemplate>
            </ComboBoxItem.Template>
        </ComboBoxItem>
    </ComboBox.Items>
