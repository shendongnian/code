<Menu DockPanel.Dock="Top">
    <MenuItem Header="SomeHeaderName" ItemsSource="{Binding Path=MyCollection}">
        <MenuItem.ItemsContainerStyle>
            <Setter Property="Header" Value="{Binding Path=SomeRelevantTextProperty}"/>
            <EventSetter Event="Click" Handler="SomeMenuItemClickEventHandler"/>
        </MenuItem.ItemsContainerStyle>
    </MenuItem>
</Menu>
In code-behind:
ObservableCollection<MyClass> MyCollection;
private void SomeMenuItemClickEventHandler(object sender, RoutedEventArgs e)
{
    MenuItem menuItem = sender as MenuItem;
    MyClass myClass = menuItem.DataContext as MyClass;
    // do something useful!
}
public class MyClass
{
    public string SomeRelevantTextProperty { get; }
}
