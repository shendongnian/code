    struct Pair
    {
        int key;
        Color colour;
    	public void print()
        {
            Console.WriteLine("key : " + key );
            Console.WriteLine("colour : " + colour);
        }
	
        // no more warning, but.. are you sure?	
		public void LOL()
		{
			key = 0;
            Color = Color.Red;
		}
    }	
