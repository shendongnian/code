    using System; 
    
    namespace starpyramid
    { 
        class program 
        { 
            static void Main() 
            { 
                Console.Write("Height: "); 
                int i = int.Parse(Console.ReadLine());
                if(i>0)
                {
                goto main;
                }
                else
                {
                	Main();
                }   
    
    			main:
                Console.Write("\n");
                for (int h = 1; h<= i;h++) // main loop for the lines
                {
                    for (int s = h; s <= i; s++) //for spaces before the stars
                    {
                        Console.Write(" ");
                    }
                    for(int j=1; j<(h*2); j=j+2)
                    {
                    	Console.Write("*");
                    }
                Console.Write("\n");
                }
        }   
        } 
    }
