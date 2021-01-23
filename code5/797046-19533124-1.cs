    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Project
    {
        class Accumulator
        {
            
    	    public int integerEntered { get; set; }		
    
            public Accumulator()
            {
            }
    
            public Accumulator(int integerPassed)
            {
    			integerEntered = integerPassed;
            }
    
            public int AccumulateValues()
            {
    			int accumulatedValue = 0;
    			if(integerEntered > 0)
    			{
    				accumulatedValue = (integerEntered * (integerEntered + 1))/2;
    			}
                return accumulatedValue;
    			
            }
    
        }
    }
