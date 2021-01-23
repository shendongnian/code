    <StackPanel Orientation="Vertical">
        <DockPanel>
            <Label Width="100" Content="{Binding Label}"
                   HorizontalAlignment="Left" VerticalAlignment="Center"/>
            <ComboBox SelectedItem="{Binding SelectedItem}" ItemsSource="{Binding ItemsSource}">
                <ComboBox.ItemTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Label}"/>
                    </DataTemplate>
                </ComboBox.ItemTemplate>
            </ComboBox>
        </DockPanel>
        <StackPanel x:Name="ContentContainer">
            <StackPanel.Resources>
                <ResourceDictionary>
            </StackPanel.Resources>
            <ContentPresenter Content="{Binding SelectedItem}"/>
        </Grid>
    <StackPanel>
