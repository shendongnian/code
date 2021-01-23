    <Window.DataContext>
        <vm:MainWindowModel />
    </Window.DataContext>
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <ListBox Grid.Column="0"  ItemsSource="{Binding Tabs}" IsSynchronizedWithCurrentItem="True" SelectedValue="{Binding SelectedTab}">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Label Content="{Binding Path=TabName}" Margin="10"/>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
        <ContentControl Grid.Column="1" Content="{Binding SelectedTab.MyUserControlViewModel"/>
    </Grid>
