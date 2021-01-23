    <Style TargetType="{x:Type MyControls:MyGrid}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type MyControls:MyGrid}">
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="500" />
                            <ColumnDefinition Width="*" />
                        </Grid.ColumnDefinitions>
                        <Grid Grid.Column="0">
                            <ContentPresenter x:Name="LeftContent" />
                        </Grid>
                        <GridSplitter Width="5" BorderBrush="#FFAAAAAA" BorderThickness="1,0,1,0">
                        </GridSplitter>
                        <Grid Grid.Column="1">
                            <ContentPresenter x:Name="RightContent" />
                        </Grid>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
