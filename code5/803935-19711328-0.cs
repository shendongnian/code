    <ComboBox ItemTemplate="{StaticResource DataTemplate}">
        <ComboBox.Resources>
            <DataTemplate x:Key="DataTemplate">
                <TextBlock Text="{Binding Content, StringFormat='Displayed via template: {0}'}" />
            </DataTemplate>
        </ComboBox.Resources>
        <ContentControl   Content="ContentControl" ContentTemplate="{StaticResource DataTemplate}" />    <-- This one ignores the DataTemplate when selected
        <ContentPresenter Content="ContentPresenter" />
    </ComboBox>
