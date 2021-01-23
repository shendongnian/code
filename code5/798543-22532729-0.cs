       // Resource file names:
        // XXX.resx (default)
        // XXX.de-DE.resx (German)
        // XXX.en-Hobbit.resx (custom) 
        static void Main()
        {
            BuildAndRegisterHobbitCulture();
            const string goodDay = "GoodDay";
            // Default.
            Console.WriteLine("{0}: {1}", Thread.CurrentThread.CurrentCulture.Name, 
                Resources.ResourceManager.GetString(goodDay));
            // German.
            SetCulture("de-DE");
            Console.WriteLine("{0}: {1}", Thread.CurrentThread.CurrentCulture.Name, 
                Resources.ResourceManager.GetString(goodDay));
            // Custom - Hobbit.
            SetCulture("en-Hobbit");
            Console.WriteLine("{0}: {1}", Thread.CurrentThread.CurrentCulture.Name, 
                Resources.ResourceManager.GetString(goodDay));
            Console.ReadLine();
        }
        private static void SetCulture(string culture)
        {
            var cultureInfo = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
        private static void BuildAndRegisterHobbitCulture()
        {
            if (CultureInfo.GetCultures(CultureTypes.AllCultures).Any(ci => ci.Name == "en-Hobbit"))
                return;
            var cultureAndRegionInfoBuilder = new CultureAndRegionInfoBuilder("en-Hobbit", CultureAndRegionModifiers.None);
            cultureAndRegionInfoBuilder.LoadDataFromCultureInfo(CultureInfo.CreateSpecificCulture("en-GB"));
            cultureAndRegionInfoBuilder.LoadDataFromRegionInfo(new RegionInfo("en-GB"));
            cultureAndRegionInfoBuilder.Register();
        }
