c#
public class CommandGroup : Freezable, ICommand
{
    public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof (object), typeof (CommandGroup));
    public object CommandParameter
    {
        get { return (object)GetValue(CommandParameterProperty); }
        set { SetValue(CommandParameterProperty, value); }
    }
    
    protected override Freezable CreateInstanceCore()
    {
        return new CommandGroup();
    }
}
See:
https://thomaslevesque.com/2011/03/21/wpf-how-to-bind-to-data-when-the-datacontext-is-not-inherited/
