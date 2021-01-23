    class Box
    {
    	vector2d Postion;
    	public Box(vector2d _position)
    	{
    		Position = _position;
    	}
    }
    
    class Boxes : list<Box>
    {
    
    	public void AddBox(Position)
    	{
    		this.add(new Box(Position));
    	}
    
    	public void Update()
    	{
    		foreach (Box b in this) {
    			//b.position += b.velocity
    		}
    	}
    
    	public void Draw()
    	{
    		foreach (Box b in this) {
    			//draw b
    		}
    	}
    }
    
    
    Boxes.AddBox(vecor2d(200,300))
