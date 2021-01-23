    <ListBox Name="ButtonList" 
                     HorizontalContentAlignment="Stretch" 
                     BorderThickness="0" 
                     ScrollViewer.HorizontalScrollBarVisibility="Disabled" 
                     Padding="0"  
                     Background="Transparent" 
                     Margin="0"
                     Grid.IsSharedSizeScope="True"
                     >
                 
                
                <ListBox.ItemsPanel>
                    <ItemsPanelTemplate >
                        <WrapPanel />
                    </ItemsPanelTemplate>
                </ListBox.ItemsPanel>
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <Grid>
                            <!-- you need the grid, otherwise buttons are different heights depending on the control -->
                            <Grid.RowDefinitions>
                                <RowDefinition SharedSizeGroup="row1"/>
                            </Grid.RowDefinitions>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition SharedSizeGroup="col1"/>
                            </Grid.ColumnDefinitions>
    <!-- put some control here --> 
    
      </Grid>
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
