    <Grid>
        <Grid.Resources>
            <DataTemplate x:Key="ContentTemplate" TargetType="{x:Type viewModel:ChildViewModel}">
                <DataGrid AutoGenerateColumns="False" . . .>
                    <DataGrid.Columns>
                        <!-- Your column definitions here -->
                    </DataGrid.Columns>
                </DataGrid>
            </DataTemplate>
        </Grid.Resources>
        <TabControl ContentTemplate="{StaticResource ContentTemplate}"  
                ItemsSource="{Binding Items}" />
    </Grid>
