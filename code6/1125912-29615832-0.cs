               Console.Write("Enter a Principle Amount: ");
               input = Console.ReadLine();
               double.TryParse(input,out p);
               if(p== 0)
    		   {
    			 Console.Write("please input valid number");
    		   }
