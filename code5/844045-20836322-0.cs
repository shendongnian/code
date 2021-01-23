    public String[] uniform(string[] numbers)
    {
		// foreach(var number in numbers) will not let you change the value 
		// of the number iteration variable, you need to work by array index
        for(int i = 0 ; i < numbers.Length; i++) 
        {
            foreach(char character in numbers[i])
            {					
                if(char.IsLetterOrDigit(character) == false)
                {
					// when you Replace you need to assign the resulting value
					// or you will just discard it
                    numbers[i]=numbers[i].Replace(character, '.'); 
					//return numbers; // not so fast! You're still looping
                }
            }
            if(numbers[i].Contains(" "))
            {
				// same as previous replace, you need to assign somewhere
                numbers[i]=numbers[i].Replace(" ","");
				// return numbers; // not so fast! You're still looping
  			}   
       }  
       return numbers; // you just need to return at the end of the iterations
    }
