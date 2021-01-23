    <ControlTemplate TargetType="{x:Type TabControl}">
        <Grid ...>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="200"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>
            <TabPanel
                Name="HeaderPanel" Grid.Column="0" ... />
            <Border Name="Border" Grid.Column="1" ... >
                <ContentPresenter ... />
            </Border>
        </Grid>
    </ControlTemplate>
