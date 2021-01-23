     <DataGrid Name="DG1" ItemsSource="{Binding}" AutoGenerateColumns="False" >
        <DataGrid.Columns>
            <DataGridHyperlinkColumn  Header="Email" Binding="{Binding Email}">
                <DataGridHyperlinkColumn.CellStyle>
                    <Style TargetType="DataGridCell">
                        <Setter Property="Background" Value="Transparent"></Setter>
                        <Setter Property="BorderThickness" Value="0"></Setter>
                        <Style.Resources>
                            <Style TargetType="Hyperlink">
                                <Setter Property="Foreground" Value="Chocolate"></Setter>
                                <Style.Triggers>
                                    <EventTrigger RoutedEvent="Hyperlink.Click">
                                        <BeginStoryboard>
                                            <Storyboard>
                                                <ColorAnimation Storyboard.TargetProperty="Foreground.Color" From="Chocolate" To="BlueViolet" Duration="0:0:0.1"></ColorAnimation>
                                            </Storyboard>
                                        </BeginStoryboard>
                                    </EventTrigger>
                                </Style.Triggers>
                            </Style>
                        </Style.Resources>
                    </Style>
                </DataGridHyperlinkColumn.CellStyle>
            </DataGridHyperlinkColumn>
        </DataGrid.Columns>
    </DataGrid>
