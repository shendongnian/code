        private class DefaultRuleFile: IRulefile
        {
          string SomeProperty
          {
            get{ return "DefaultValue"; }
          }
        }
    
        [Export( typeof( IRulefile ) )]    
        [Export( typeof( RuleFileImplementation ) )]    
        [PartCreationPolicy(CreationPolicy.Shared)]
        public class RuleFileImplementation : IRulefile
        {
          private IRuleFile impl;
    
          RuleFileImplementation()
          {
            impl = new DefaultRuleFile();
          }
    
          string SomeProperty
          {
            get{ return impl.SomeProperty; }
          }
    
          void LoadFromFile( string file )
          {
            impl = SerializationHelper.Deserialize<IRuleFile>( file );
          }
        }
        //at some point in the application:
        container.GetExportedValue<RuleFileImplementation>().LoadFromFile( "file" )
