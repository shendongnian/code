    void Main()
    {
    	var restaurants = new List<Restaurant>();
    	restaurants.Add(new Restaurant(1, "McDonalds"));
    	restaurants.Add(new Restaurant(2, "Wendy's"));
    	restaurants.Add(new Restaurant(3, "KFC"));
    	
    	var comments = new List<Comment>();
    	comments.Add(new Comment(1, 1, "I love clowns!", 9));
    	comments.Add(new Comment(2, 1, "Disgusting", 1));
    	comments.Add(new Comment(3, 1, "Average", 5));
    	comments.Add(new Comment(4, 2, "Hmmm tasty", 8));
    	comments.Add(new Comment(5, 2, "Yuck", 4));
    	comments.Add(new Comment(6, 3, "Chicken!", 10));
    	
    	var restaurantsWithRatings = restaurants.Select(r => new {
    				RestaurantId = r.RestaurantId,
    				Name = r.Name,
    				Rating = (
    					comments.Where(c => c.RestaurantId == r.RestaurantId).Average(c => c.Rating)
    				)
    			});
    		
    	foreach(var r in restaurantsWithRatings)
    		Console.WriteLine("{0}: {1}", r.Name, r.Rating);
    }
    
    class Restaurant
    {
    	public Restaurant(int restaurantId, string name)
    	{
    		RestaurantId = restaurantId;
    		Name = name;
    	}
    	
    	public int RestaurantId { get; set; }
    	public string Name { get; set; }
    }
    
    class Comment
    {
    	public Comment(int commentId, int restaurantId, string message, int rating)
    	{
    		CommentId = commentId;
    		RestaurantId = restaurantId;
    		Message = message;
    		Rating = rating;
    	}
    	
    	public int CommentId { get; set; }
    	public int RestaurantId { get; set; }
    	public string Message { get; set; }
    	public int Rating { get; set; }
    }
