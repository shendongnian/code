      <Grid>
        <ItemsControl ItemsSource="{Binding A}" >
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal" >
                        <Label Content="{Binding Heading}" BorderThickness="2, 0, 2, 2" BorderBrush="Black"/>
                        <ItemsControl ItemsSource="{Binding Values}">
                            <ItemsControl.ItemsPanel>
                                <ItemsPanelTemplate>
                                    <StackPanel Orientation="Horizontal"/>
                                </ItemsPanelTemplate>
                            </ItemsControl.ItemsPanel>
                            <ItemsControl.ItemTemplate>
                                <DataTemplate>
                                    <StackPanel Orientation="Horizontal">
                                        <Label Content="{Binding}" BorderThickness="0, 0, 2, 2" BorderBrush="Black"/>
                                       
                                    </StackPanel>
                                </DataTemplate>
                            </ItemsControl.ItemTemplate>
                        </ItemsControl>
                    </StackPanel>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Grid>
