    <ListView Name="MyListView" 
    <!-- COMMENT ItemsSource="{Binding MySimpleData}"> END COMMENT-->
    ItemsSource="{Binding CanvasCollection}"> <!-- EDIT HERE -->
    AlternationCount="{Binding CanvasCollection.Count}"
    <ListView.ItemsPanel>
        <ItemsPanelTemplate>
            <StackPanel Orientation="Horizontal"/>
        </ItemsPanelTemplate>
    </ListView.ItemsPanel>
    <ListView.View>
        <GridView>
            <GridView.Columns>
              <!-- COMMENT <GridViewColumn Header="Column1"
              DisplayMemberBinding="{Binding}"/> END COMMENT -->
                  <GridViewColumn Header="Index" Width="37">
                    <GridViewColumn.CellTemplate> <!-- NEW Index displaying code -->
                            <DataTemplate>
                                <Label Content="{Binding RelativeSource={RelativeSource AncestorType={x:Type ListViewItem}}, Path=(ItemsControl.AlternationIndex)}" />
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                <GridViewColumn Header="Column2-Canvases" 
                                Width="{Binding DataContext.CanvasWidth, RelativeSource={RelativeSource AncestorType={x:Type UserControl}}}" >
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
              <!-- COMMENT      <Canvas
                                Width="{Binding DataContext.CanvasWidth, RelativeSource={RelativeSource AncestorType={x:Type UserControl}}}" 
                                Height="{Binding DataContext.CanvasHeight, RelativeSource={RelativeSource AncestorType={x:Type UserControl}}}"
                                Background="LightSlateGray"/> END COMMENT -->
                                <ContentPresenter Content="{Binding}" /> <!-- NEW -->
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
            </GridView.Columns>
        </GridView>
    </ListView.View>
