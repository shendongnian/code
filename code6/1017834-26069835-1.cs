            <local:CustomItemsControl x:Name="ItControl" ItemTemplate="{StaticResource DefaultGridItemTemplate}">
                   <ItemsControl.ItemsPanel>
     
    <ItemsPanelTemplate>
                        <Grid >
                            <Grid.RowDefinitions>
                                <RowDefinition />
                                <RowDefinition />
                                <RowDefinition/>
                            </Grid.RowDefinitions>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition />
                                <ColumnDefinition />
                                <ColumnDefinition/>
                            </Grid.ColumnDefinitions>
                        </Grid>
                    </ItemsPanelTemplate>
                </ItemsControl.ItemsPanel>
                <!--<ItemsControl.ItemContainerStyle>
                    <Style TargetType="ContentPresenter">
                        <Setter Property="Grid.Column" Value="{Binding Col}" />
                        <Setter Property="Grid.Row" Value="{Binding Row}"/>
                    </Style>
                </ItemsControl.ItemContainerStyle>-->
            </local:CustomItemsControl>
