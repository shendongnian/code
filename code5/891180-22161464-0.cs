    List<Pipe> pipes = new List<Pipe>();
    int spawnfactor = 5;
    int spawns = 0; //or 1, if you want the first spawn to occur at 1 second
    
    protected override void Update()
    {
        elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
    
        if (elapsedTime == spawnfactor * spawns)
        {
            pipes.Add(New Pipe());
            spawns++; //keep track of how many spawns we've had
        }
    
        for (int i = 0; i < pipes.Count; i++)
        {
            pipes[i].Update();//update each pipe in the list.
        }
    }
    
    protected override void Draw()
    {
        for (int i = 0; i < pipes.Count; i++)
        {
            pipes[i].Draw();
        }
    }
