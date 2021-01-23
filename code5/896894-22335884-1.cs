    <GridViewColumn Header="Active Engines">
       <GridViewColumn.CellTemplate>
          <DataTemplate>
             <ItemsControl ItemsSource="{Binding _engine}" DisplayMemberPath="_name">
                <ItemsControl.ItemsPanel>
                   <ItemsPanelTemplate>
                      <StackPanel Orientation="Horizontal"/>
                   </ItemsPanelTemplate>
                </ItemsControl.ItemsPanel>
             </ItemsControl>
          </DataTemplate>
       </GridViewColumn.CellTemplate>
    </GridViewColumn>
