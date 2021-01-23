    using System;
    
    namespace Test
    {
       
        public class TopNavigationConst {
            private const string SAVE = "Save";
            private const string REFRESH = "Refresh";
            
            public String Save {get{return SAVE; }}
            public String Refresh {get{return REFRESH;}}
        }
    
        public class ErrorsConst
        {
            public const string UNESPECTEDERROR = "An unexpected error occured.";
            public String UnexpectedError {get{return UNESPECTEDERROR; }}
        }
        
        public class ControlsConst 
        {
            private TopNavigationConst topNavigation = new TopNavigationConst();
            public TopNavigationConst TopNavigation {get{return topNavigation;}}
        }
        
         public class GeneralConst
        {
            public ErrorsConst errors = new ErrorsConst();
            public ErrorsConst Errors {get{return errors;}}
        }
    
        public class LabelsConst
        {
            public static ControlsConst controls = new ControlsConst();
            public static GeneralConst general = new GeneralConst();
            
            public ControlsConst Controls {get{return controls;}}
            public GeneralConst General {get{return general;}}
        }
    
        public class Constants
        {
            public static LabelsConst labels = new LabelsConst();
            public static LabelsConst Labels {get{return labels;}}
        }
        
        public class Test
        {
            public static void Main()
            {
                var value = Constants.Labels.Controls.TopNavigation.Save;
                System.Console.WriteLine(value);
                
            }
        }
     
       
        
    }
