    class Plugin
    {
    [ImportMany]
    public IEnumerable<IDataProvider> DataProvider { get; set; }
    //add this
    [ImportMany(typeof(IView), AllowRecomposition = true)]
		public IEnumerable<Lazy<IView,IMetaData>> Plugins
		{
			get;
			set;
		}
    public Plugin()
    {
        try
        {
            AggregateCatalog aggregatecatalogue = new AggregateCatalog();               
            aggregatecatalogue.Catalogs.Add(new AssemblyCatalog(Assembly.LoadFile("...\\Data1.dll")));
            aggregatecatalogue.Catalogs.Add(new AssemblyCatalog(Assembly.LoadFile("...\\Data2.dll")));
            aggregatecatalogue.Catalogs.Add(new AssemblyCatalog(Assembly.GetAssembly(typeof(IDataProvider))));
            CompositionContainer container = new CompositionContainer(aggregatecatalogue);
            container.ComposeParts(this);
        }
        catch (FileNotFoundException fnfex)
        {
            Console.WriteLine(fnfex.Message);
        }
        catch (CompositionException cex)
        {
            Console.WriteLine(cex.Message);
        }
    }
