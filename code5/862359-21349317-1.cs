    <GridView ItemsSource="{Binding Path=CheckedItemCollection, 
                                    Mode=TwoWay, 
                                    UpdateSourceTrigger=PropertyChanged, 
                                    IsAsync=True}" 
        <GridView.Columns>
            <GridViewColumn.CellTemplate>
                <DataTemplate>
                    <CheckBox Content="{Binding Text}" 
                              IsChecked="{Binding IsSelected, 
                                                  Mode=TwoWay, 
                                                  UpdateSourceTrigger=PropertyChanged, 
                                                  IsAsync=True}"/>
                </DataTemplate>
            </GridViewColumn.CellTemplate>
        </GridView.Columns>
    </GridView>
    
