            public string PropertyA { get; set; }
            public virtual string GetString() //
            {
                return PropertyA;
            }
        }
        public class B:A
        {
            public string PropertyB { get; set; }
            public override string GetString()
            {
                return PropertyB;
            }
        }
        public class C:A
        {
            public string PropertyC { get; set; }
            public override string GetString()
            {
                return string.Format("{0} - {1}", base.GetString(), PropertyC) // for example if you wanted to do something more complex
            }
        }
