    <ListBox ItemsSource="{Binding Places}">
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="Tap">
                <i:InvokeCommandAction Command="{Binding ListBoxClick}" 
    CommandParameter="{Binding SelectedItem, RelativeSource={RelativeSource AncestorType={
    x:Type ListBox}}}" />
            </i:EventTrigger>
        </i:Interaction.Triggers>
        <ListBox.ItemTemplate>
            <DataTemplate>
                (...)
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
