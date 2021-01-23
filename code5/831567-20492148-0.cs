    <Grid Visibility="{Binding ElementName=toggleButton, Path=IsChecked, Converter=
        {StaticResource BoolToVisConverter}}" Grid.IsSharedSizeScope="True">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*" SharedSizeGroup="FirstColumn" />
            <ColumnDefinition Width="Auto" SharedSizeGroup="GridSplitterColumn" />
            <ColumnDefinition Width="*" SharedSizeGroup="LastColumn" />
        </Grid.ColumnDefinitions>
        ...
    </Grid>
