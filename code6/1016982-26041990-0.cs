    <Grid>
        <ListView x:Name="LV">
            <ListView.ContextMenu>
                <ContextMenu>
                    <Label Content="Your menu item..."/>
                </ContextMenu>
            </ListView.ContextMenu>
            
            <ListView.View>
                <GridView>
                    <GridViewColumn DisplayMemberBinding="{Binding Path=IsChecked}" 
                                    Header="IsFinished"/>
                </GridView>
            </ListView.View>
            
            <ListView.Style>
                <Style>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding SelectedItem.IsChecked, 
                                                       ElementName=LV}" Value="True">
                            <Setter Property="ContextMenuService.IsEnabled" 
                                    Value="False"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </ListView.Style>
            <CheckBox IsChecked="False"/>
            <CheckBox IsChecked="True"/>
        </ListView>
    </Grid>
