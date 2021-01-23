    <telerik:RadGridView Grid.Row="1"
            ItemsSource="{Binding Path=Locations}"
            SelectionMode="Multiple"
            ShowGroupPanel="False"
            ShowColumnFooters="true"
            atchbhv:RadGridViewMultipleSelection.SelectedItemsSource="{Binding SelectedLocations}"
            IsEnabled="{Binding SelectAllLocations, Converter={StaticResource InverseBooleanConv}}">
                    <telerik:RadGridView.Columns>
                           <telerik:GridViewDataColumn Header="LocHandle"DataMemberBinding="{Binding Path=Item1.LocHandle}">
                                   <telerik:GridViewDataColumn.AggregateFunctions>
                                           <telerik:CountFunction Caption="Count: " />
                                   </telerik:GridViewDataColumn.AggregateFunctions>
                           </telerik:GridViewDataColumn>
                          <telerik:GridViewDataColumn Header="LocDesc"DataMemberBinding="{Binding Path=Item1.LocDesc}"/>
                    </telerik:RadGridView.Columns>
    </telerik:RadGridView>
