Command="{Binding DataContext.TestCmd, ElementName=Parent_UC}"
CommandParameter="{Binding DataContext, RelativeSource={RelativeSource Mode=Self}}"
If using events, use the sender.
private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
{
   if(sender is Button b)
   {
      if(b.DataContext is ClassType t)
      { enter code here }
   }
}
