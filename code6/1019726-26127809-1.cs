    <ItemsControl 
        ItemsSource="{Binding DocumentTypeCount.DocumentTypeCountList}"
        Grid.IsSharedSizeScope="True">
        <ItemsControl.ItemTemplate>            
            <DataTemplate>
                <Grid>
                    <Grid.Resources>
                        <Style TargetType="{x:Type TextBlock}">
                            <Setter Property="FontWeight" Value="Normal"/>
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding IsTotals}" Value="True">
                                    <Setter Property="FontWeight" Value="Bold"/>
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </Grid.Resources>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition SharedSizeGroup="column1"/>
                        <ColumnDefinition SharedSizeGroup="column2"/>
                    </Grid.ColumnDefinitions>
                    <TextBlock Text="{Binding DocumentTypeName}" Grid.Column="0"/>
                    <TextBlock Text="{Binding Count}" Grid.Column="1"/>
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
