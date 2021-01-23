    using System.ComponentModel;
    
    namespace myCompany.MyProject.BO {
        public enum SampleTypes
        {
            // Default          
            [Description("- None -")]
            None=0,
    
            [Description("My type 1")]
            V1=1,
            
            [Description("My type 2)]
            V2=2,
            
            [Description("My type 3")]
            V3=3
        } }
