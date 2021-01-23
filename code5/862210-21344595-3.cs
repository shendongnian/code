    <ItemsControl x:Name="items"> 
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition />
                        <ColumnDefinition />
                    </Grid.ColumnDefinitions>
                    <StackPanel DataContext="{Binding Item1}" Grid.Column="0" Orientation="Horizontal">
                        <TextBlock Text="{Binding name}" Width="150" />
                        <Image Source="{Binding fotoPath}" />
                    </StackPanel>
                    <StackPanel DataContext="{Binding Item2}" Grid.Column="1" Orientation="Horizontal">
                        <TextBlock Text="{Binding name}" Width="150" />
                        <Image Source="{Binding fotoPath}" />
                    </StackPanel>
                <Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
