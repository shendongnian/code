    <DataGridTextColumn Binding="{Binding Path=value1}" >
        <DataGridTextColumn.Header>                                       
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition/>
                    <ColumnDefinition/>
                </Grid.ColumnDefinitions>
                <TextBox Grid.Column="1" Text="{Binding}" IsReadOnly="{Binding IsChecked, 
    ElementName=chkValue}" />
                <CheckBox Name="chkValue1"  Grid.Column="0" Width="16" IsChecked="{Binding 
    RelativeSource={RelativeSource AncestorType={x:Type DataGridColumn}}, Path=
    DataContext.AllItemsAreChecked}" />
            </Grid>
        </DataGridTextColumn.Header>                                    
    </DataGridTextColumn>
