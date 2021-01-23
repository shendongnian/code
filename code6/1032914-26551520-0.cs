    [System.AttributeUsage(System.AttributeTargets.Property)]
        [Serializable]
        class Configureable : LocationInterceptionAspect 
        {
            public string Default { get; set; }
            public bool IsEncrypted { get; set; }
    
            public override void OnGetValue(LocationInterceptionArgs args)
            {
                base.OnGetValue(args);
                if (args.Value == null)
                {
                    
                }
            }
    
            public override void OnSetValue(LocationInterceptionArgs args)
            {
                //base.OnSetValue(args);
            }
        }
    
        
        class Test
        {
            [Configureable(Default = "0",IsEncrypted = false)]
            public string MyValue { get; set; }
        }
