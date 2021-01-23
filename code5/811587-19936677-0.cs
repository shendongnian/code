    using Castle.Core;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel;
    using Castle.MicroKernel.ComponentActivator;
    using Castle.MicroKernel.Context;
    using Castle.MicroKernel.Facilities;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using ViewFun.Castle;
    using ViewFun.Common;
    using ViewFun.View;
    using ViewFun.ViewModels;
    namespace ViewFun
    {
        namespace Common
        {
            public interface IView
            {
                void PrintViewModelName();
            }
            public interface IViewModel
            {
            }
            public interface IViewFactory : IDisposable
            {
                TView CreateView<TView>();
                void DestroyView<TView>(TView view);
            }
        }
        namespace ViewModels
        {
            public interface IMainViewModel : IViewModel
            {
            }
            public interface ISecondaryViewModel : IViewModel
            {
            }
            public interface ISecondary2ViewModel : IViewModel
            {
            }
            public class MainViewModel : IMainViewModel
            {
            }
            public class SecondaryViewModel : ISecondaryViewModel
            {
            }
            public class Secondary2ViewModel : ISecondary2ViewModel
            {
            }
        }
        namespace View
        {
            public interface IMainView : IView, IDisposable
            {
                void ShowView<TView>()
                    where TView : IView;
            }
            public interface ISecondaryView : IView
            {
            }
            public interface ISecondaryView2 : IView
            {
            }
        }
        namespace WPFImplementation
        {
            public class MainWindow : Window, IMainView, IDisposable
            {
                private readonly IViewFactory viewFactory;
                public MainWindow(IMainViewModel viewModel, IViewFactory viewFactory)
                {
                    this.viewFactory = viewFactory;
                }
                public void PrintViewModelName()
                {
                    Console.WriteLine(string.Format("The main window is of type {0} with a view model type of {1}", this.GetType(), this.DataContext.GetType().Name));
                    Console.WriteLine();
                    Console.WriteLine();
                }
                public void ShowView<TView>()
                    where TView : IView
                {
                    IView view = this.viewFactory.CreateView<TView>();
                    Console.WriteLine(view.GetType().Name);
                    view.PrintViewModelName();
                }
                public void Dispose()
                {
                    this.viewFactory.Dispose();
                }
            }
            public class SecondaryWPFView1 : Window, ISecondaryView
            {
                public SecondaryWPFView1(ISecondaryViewModel viewModel)
                {
                }
                public void PrintViewModelName()
                {
                    Console.WriteLine(string.Format("One of the secondary windows is of type {0} with a view model type of {1}", this.GetType(), this.DataContext.GetType().Name));
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            public class SecondaryWPFView2 : Window, ISecondaryView2
            {
                public SecondaryWPFView2(ISecondary2ViewModel viewModel)
                {
                }
                public void PrintViewModelName()
                {
                    Console.WriteLine(string.Format("The other secondary window is of type {0} with a view model type of {1}", this.GetType(), this.DataContext.GetType().Name));
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }
        namespace Castle
        {
            public class WpfInstaller : IWindsorInstaller
            {
                    private static string AssemblyDirectory
                    {
                        get
                        {
                            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                            var uri = new UriBuilder(codeBase);
                            string path = Uri.UnescapeDataString(uri.Path);
                            return Path.GetDirectoryName(path);
                        }
                    }
                    public void Install(IWindsorContainer container, IConfigurationStore store)
                    {
                        container.AddFacility<WpfViewCreaterFacility>()
                            .Register(
                                Classes.FromAssemblyInDirectory(new AssemblyFilter(AssemblyDirectory))
                                    .BasedOn<IView>()
                                    .Configure(c => c.LifestyleTransient().Named(c.Implementation.Name))
                                    .WithService.Base()
                                    .WithService.FromInterface(typeof(IView)),
                                Classes.FromAssemblyInDirectory(new AssemblyFilter(AssemblyDirectory))
                                    .BasedOn<IViewModel>()
                                    .Configure(c => c.LifestyleTransient().Named(c.Implementation.Name))
                                    .WithService.Base()
                                    .WithService.FromInterface(typeof(IViewModel)),
                                Component.For<IViewFactory>()
                                    .AsFactory()
                                    .LifestyleTransient());
                    }
            }
            public class WpfViewCreaterFacility : AbstractFacility
            {
                protected override void Init()
                {
                    this.Kernel.ComponentModelCreated += this.RegisterComponentActivator;
                }
                private void RegisterComponentActivator(ComponentModel model)
                {
                    bool isView = typeof(IView).IsAssignableFrom(model.Services.First());
                    if (!isView)
                    {
                        return;
                    }
                    if (model.CustomComponentActivator == null)
                    {
                        model.CustomComponentActivator = typeof(WpfViewCreater);
                    }
                }
            }
            public class WpfViewCreater : DefaultComponentActivator
            {
                public WpfViewCreater(
                    ComponentModel model,
                    IKernel kernel,
                    ComponentInstanceDelegate onCreation,
                    ComponentInstanceDelegate onDestruction)
                    : base(model, kernel, onCreation, onDestruction)
                {
                }
                protected override object CreateInstance(
                    CreationContext context, ConstructorCandidate constructor, object[] arguments)
                {
                    object component = base.CreateInstance(context, constructor, arguments);
                    var frameworkElement = component as FrameworkElement;
                    if (frameworkElement != null && arguments != null)
                    {
                        object viewModel = arguments.FirstOrDefault(vm => vm is IViewModel);
                        if (viewModel != null)
                        {
                            frameworkElement.DataContext = viewModel;
                        }
                    }
                    return component;
                }
            }
        }
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                IWindsorContainer container = new WindsorContainer();
                container.AddFacility<TypedFactoryFacility>();
                container.Install(new WpfInstaller());
                IMainView mainView = container.Resolve<IMainView>();
                mainView.PrintViewModelName();
                mainView.ShowView<ISecondaryView>();
                mainView.ShowView<ISecondaryView2>();
                mainView.Dispose();
                Console.ReadLine();
            }
        }
    }
