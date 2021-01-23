    <ItemsControl x:Name="items"> 
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.Resources>
                        <DataTemplate x:Key="ColumnTemplate">
                            <StackPanel Orientation="Horizontal">
                                <TextBlock Text="{Binding name}" Width="150" />
                                <Image Source="{Binding fotoPath}" />
                            </StackPanel>
                        </DataTemplate>
                    </Grid.Resources>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition />
                        <ColumnDefinition />
                    </Grid.ColumnDefinitions>
                    <ContentControl Content="{Binding Item1}" 
                                    ContentTemplate="{StaticResource ColumnTemplate}" />
                    <ContentControl Grid.Column="1" 
                                    Content="{Binding Item2}" 
                                    ContentTemplate="{StaticResource ColumnTemplate}" />
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
