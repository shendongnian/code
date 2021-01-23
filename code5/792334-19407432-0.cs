    <ListView.Resources>
        <ContextMenu x:Key="ContextMenu" DataContext="{Binding PlacementTarget.Tag, 
            RelativeSource={RelativeSource Self}}">
            <MenuItem Header="Run test with parameters" x:Name="runTestWithParams" 
                Click="runTestWithParams_Click" />
        </ContextMenu>
    </ListView.Resources>
    <ListView.ItemTemplate>
        <DataTemplate DataType="{x:Type YourNamespace:YourDataType}">
            <Grid Tag="{Binding DataContext, RelativeSource={RelativeSource Self}}" 
                ContextMenu="{StaticResource ContextMenu}">
                <!--Define what your data objects look like here or just use this-->
                <TextBlock Text="{Binding}" />
            </Grid>
        </DataTemplate>
    </ListView.ItemTemplate>
