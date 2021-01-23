    ...
    <Window.Resources>
        <local:ColorConverter x:Key="colorConverter" />
    </Window.Resources>
    <Grid>
        <DataGrid ItemsSource="{Binding}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding EBIT}">
                    <DataGridTextColumn.ElementStyle>
                        <Style TargetType="{x:Type TextBlock}">
                            <Setter Property="Background" Value="{Binding EBIT, Converter={StaticResource colorConverter}, ConverterParameter='&gt; 12'}"/>
                        </Style>
                    </DataGridTextColumn.ElementStyle>
                </DataGridTextColumn>
                <DataGridTextColumn Binding="{Binding RoE}">
                    <DataGridTextColumn.ElementStyle>
                        <Style TargetType="{x:Type TextBlock}">
                            <Setter Property="Background" Value="{Binding RoE, Converter={StaticResource colorConverter}, ConverterParameter='&lt; 20'}"/>
                        </Style>
                    </DataGridTextColumn.ElementStyle>
                </DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
    ...
