     public void CountDollers(int number) {
                int[] values = new int[] { 1000, 100, 50,1 }; // declare here your counter serise            
                int i = 0 ,rem = 0;
                do
                {
                    rem = number / values[i];
                    Console.WriteLine("Number of "+values[i]+"$ "+ rem);
                    number = number % values[i];                             
                    i++;
                } while (number > values[values.Length-1]-1);            
            }
    
