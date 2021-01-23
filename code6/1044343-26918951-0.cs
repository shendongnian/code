    <Page.Resources>
        <DataTemplate x:Key="AddTemplate">
            <Button Command="{Binding}" Content="{Binding Title}" Height="100" MinHeight="100" Width="100" MinWidth="100"/>
        </DataTemplate>
        <DataTemplate x:Key="DefaultTemplate">
            <Border BorderThickness="1" BorderBrush="Red">
                <StackPanel Height="100" MinHeight="100" Width="100" MinWidth="100">
                    <TextBlock Text="{Binding Artist}"></TextBlock>
                    <TextBlock Text="{Binding Song}"></TextBlock>
                </StackPanel>
            </Border>
        </DataTemplate>
        <local:MyTemplateSelector x:Key="MyTemplateSelector" AddTemplate="{StaticResource AddTemplate}" DefaultTemplate="{StaticResource DefaultTemplate}"></local:MyTemplateSelector>
    </Page.Resources>
    <GridView x:Name="myGV" ItemTemplateSelector="{StaticResource MyTemplateSelector}"></GridView>        
----------
    public class MyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AddTemplate { get; set; }
        
        public DataTemplate DefaultTemplate { get; set; }
        protected override Windows.UI.Xaml.DataTemplate SelectTemplateCore(object item, Windows.UI.Xaml.DependencyObject container)
        {
            if (item is sample_model)
            {
                return DefaultTemplate;
            }
            else
            {
                return AddTemplate;
            }
        }
    }
