    <ListView
        ItemsSource="{Binding MyDataView, Mode=TwoWay, 
            NotifyOnTargetUpdated=True, NotifyOnSourceUpdated=True, 
            UpdateSourceTrigger=PropertyChanged}"                               
        x:Name=MyListView" Height="291">                               
        <ListView.View>
            <GridView x:Name="GridView1">
                 <GridViewColumn x:Name="ColumnToSort" 
                         DisplayMemberBinding="{Binding Path=position}">
                     <!--<GridViewColumn.Header>
                          <GridViewColumnHeader Tag="position"/>
                          </GridViewColumn.Header>-->
                 </GridViewColumn>
            </GridView>
        </ListView.View>
    </ListView>
