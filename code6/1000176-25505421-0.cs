    <Grid Margin="10">
        <Grid.RowDefinitions>
            <RowDefinition></RowDefinition>
            <RowDefinition></RowDefinition>
        </Grid.RowDefinitions>
        <DataGrid AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Name"/>
                <DataGridTextColumn Header="Number" 
                    Visibility="{Binding DataContext.IsPartnerColumnVisible, 
                    Source={x:Reference FrameworkElement}}"/>    
            </DataGrid.Columns>
        </DataGrid>
        <FrameworkElement Name="someElement" Grid.Row="1" Visibility="Collapsed" />    
    </Grid>
