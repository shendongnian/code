	using System;
	using System.Linq;
	using Microsoft.Practices.Unity;
    class Program
    {
        static void Main(string[] args)
        {
            // Begin Composition Root
            var container = new UnityContainer();
            // IMPORTANT: For Unity to resolve arrays, you MUST name the instances.
            container.RegisterType<ITranslator, ModelToViewModelTranslator>("ModelToViewModelTranslator");
            container.RegisterType<ITranslator, ViewModelToModelTranslator>("ViewModelToModelTranslator");
            container.RegisterType<ITranslatorStrategy, TranslatorStrategy>();
            container.RegisterType<ISomeService, SomeService>();
			// Instantiate a service
            var service = container.Resolve<ISomeService>();
			
			// End Composition Root
			
			// Do something with the service
            service.DoSomething();
        }
    }
    public interface ISomeService
    {
        void DoSomething();
    }
    public class SomeService : ISomeService
    {
        private readonly ITranslatorStrategy translatorStrategy;
        public SomeService(ITranslatorStrategy translatorStrategy)
        {
            if (translatorStrategy == null)
                throw new ArgumentNullException("translatorStrategy");
            this.translatorStrategy = translatorStrategy;
        }
        public void DoSomething()
        {
            // Create a Model
            Model model = new Model() { Property1 = "Hello", Property2 = 123 };
            // Translate to ViewModel
            ViewModel viewModel = this.translatorStrategy.Translate<Model, ViewModel>(model);
            // Translate back to Model
            Model model2 = this.translatorStrategy.Translate<ViewModel, Model>(viewModel);
        }
    }
