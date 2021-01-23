    <UserControl DataContext="ViewModel1">
        <Grid>    
            <ListView ItemsSource="{Binding TimeSlotCollection}" />
            <UserControl DataContext="{Binding TimeSlotCollection}">
                ... 
                <!-- Then inside the inner control -->
                <DataGrid x:Name="DataGrid" ItemsSource="{Binding}" ... />
                ...
            </UserControl>
        </Grid>
    </UserControl> 
