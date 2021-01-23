    public class CommandBuilder
    {
        ParameterParser _parser = new ParameterParser();
        Dictionary<string, Func<Setting, Command>> _builders = new Dictionary<string, Func<Setting, Command>>();
    
        public IEnumerable<Command> Build(string config)
        {
            var settings = _parser.Parse(config);
            foreach (var setting in settings)
            {
                yield return _builders[setting.Name].Build(setting);
            }
        }
        public void Register(string name, Func<Setting, Command> builder)
        {
            _builders[name] = builder;
        }
    
    }
