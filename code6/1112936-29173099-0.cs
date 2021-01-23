    int y = 0;
    
    // Accesses each line one at a time
    foreach (string line in eachLine)
    {
        // reset the x position to the beginning of each line.
        int x = 0;
        // Accesses each character in each line one at a time
        foreach(char c in line)
        {
            string currentNum = c.ToString();
            thisNum = Convert.ToInt32(currentNum);
            
            if (thisNum == 1)
            {
                // Create a single object at x,y (no looping here)
                ObjectSpawnPosition = new Vector3(x,y,0);
                Instantiate(obj, ObjectSpawnPosition, Quaternion.identity);
            }
            // increment x inside the inner loop.
            x++;
        }
        // done with a line, so increment y to go to the next line.
        y++;
    }
  
