    $source = @"
    using System;
    
    namespace AlertsOnOff
    {
        public class onOff
        {
            public static void Main(string[] args)
            {
                 if(args[0] == `"on`")
                 {
    			      Console.WriteLine(`"foo`");
    			 }
                 if(args[0] == `"off`")
                 { 
    			      Console.WriteLine(`"bar`");
    		     }
            }
    	}
    }
    "@
    
    Add-Type -TypeDefinition $Source
    [AlertsOnOff.onOff]::Main("off")
    
    # Other code here
    
    [AlertsOnOff.onOff]::Main("on")
