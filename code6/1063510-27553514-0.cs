    public bool thread_completed = true;
            public void RunAwayFromNeighbours()
            {
                thread_completed = false;
                object x = new object() ;
                Monitor.Enter(x);
                try
                {
                    var neighbours = CheckForNeighbours().ToList();
                    foreach (Particle p in neighbours)
                    {
                        Vector2 where_to_run = location.GetXY() - p.location.GetXY();
                        speed += where_to_run * run_speed_q;
                        
                    }
                }
                finally
                {
    
                    Monitor.Exit(x);
                    thread_completed = true;
                }
