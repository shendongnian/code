    <DataGrid.ContextMenu>
                <ContextMenu>
                    <MenuItem  >
                        <MenuItem.Header>
                            <StackPanel Orientation="Horizontal">
                                <ComboBox Margin="5 0" x:Name="comboBox">
                                    <ComboBoxItem>1</ComboBoxItem>
                                    <ComboBoxItem>2</ComboBoxItem>
                                    <ComboBoxItem>3</ComboBoxItem>
                                </ComboBox>
                                <TextBlock Margin="5 0" 
                                           Text="{Binding Source={x:Reference comboBox}, 
                                           Path=Text}">
                               </TextBlock>
                            </StackPanel>
                        </MenuItem.Header>
                    </MenuItem>
                </ContextMenu>
            </DataGrid.ContextMenu>
