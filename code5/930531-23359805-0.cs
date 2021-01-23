    void Main()
    {
    	       string line = Console.ReadLine();
    	       bool result;
    	       for(int i=0; i<line.Length; i++)
    		   {
    	           result = checkChar(line[i]);
    	           if(!result)
    	               continue;
    				Console.WriteLine(line[i]);
    			}
    }
    
    
    static bool checkChar(char input)
    {
       char[] letters={'f', 'g', 'h'};
       return letters.Contains(input);
    }
