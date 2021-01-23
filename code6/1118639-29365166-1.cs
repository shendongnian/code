    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Button Name="button_WithDoubleClick" Content="Button with double click" MouseDoubleClick="button_WithDoubleClick_MouseDoubleClick" />
        <Button Grid.Row="1" Name="button_RaiseDoubleClick" Content="Button to raise double click" Click="button_RaiseDoubleClick_Click"/>
    </Grid>
