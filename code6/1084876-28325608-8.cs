    public static class RandomValueGeneratorFactory
    {
        public static IRandomValueGenerator GetGenerator()
        {
            string type = System.Configuration.ConfigurationManager.AppSettings["randomValueGenerator"];
            IRandomValueGenerator valueGenerator;
            switch (type)
            {
                case "random":
                    valueGenerator = new RealRandomValueGenerator();
                    break;
                case "fake":
                    valueGenerator = new FakeRandomValueGenerator();
                    break;
                default:
                    throw new System.Configuration.ConfigurationException("Unsupported value for randomValueGenerator: " + type);
            }
            return valueGenerator;
        }
    }
