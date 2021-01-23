    <GridViewColumn Header="Active Engines">
       <GridViewColumn.CellTemplate>
          <DataTemplate>
             <ItemsControl ItemsSource="{Binding _engine}" DisplayMemberPath="_name"/>
          </DataTemplate>
       </GridViewColumn.CellTemplate>
    </GridViewColumn>
