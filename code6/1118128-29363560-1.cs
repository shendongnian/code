    public class PersonSearchServiceModule : NinjectModule 
    {
        public override void Load()
        {
            this.Bind<IPersonSearchService>().To<PersonSearchService>();
        }
    }
