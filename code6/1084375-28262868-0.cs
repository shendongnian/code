        //Register with Windsor
        public class ViewInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Register(Component.For<IShellViewModel>().ImplementedBy<ShellViewModel>().LifestyleSingleton());
                container.Register(Component.For<IFooViewModel >().ImplementedBy<FooViewModel>().LifestyleSingleton());
            }
        }
    <Window x:Class="CM.Views.ShellView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation">
    
    <Button cal:Message.Attach="[Event Click]=[Action About]" cal:Action.Target="CM.ViewModels.FooViewModel"/>
    </Window>
    namespace CM.ViewModels
     {
        public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShellViewModel
        {
            public ShellViewModel()
            {
            }
       }
    
       public class FooViewModel : IFooViewModel
       {
             public void About()
             {
                 MessageBox.Show("About method fired");
             }
       }
    }
