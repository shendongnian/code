    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace RegexTest
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			string s1, s2, s0;
    			//Regex regex;
    			Match match;
    			s0 = "l'insostenibile leggerezza dell'essere";
    			s1 = "g.+z";
    			s2 = "'.*'";
    			try
    			{
    				match = Regex.Match(s0, s1);
    				if(match.Success)
    				{
    				}
    				else
    				{
    				}
    				match = Regex.Match(s0, s2);
    				if(match.Success)
    				{
    				}
    				else
    				{
    				}
    				s1 = "x.+r";
    				match = Regex.Match(s0, s1);
    				if(match.Success)
    				{
    				}
    				else
    				{
    				}
    			}
    			catch(Exception ex)
    			{
    			}
    
    		}
    	}
    }
