    using System.IO;
    using System;
    using System.Collections.Generic;
    
    class Program
    {
      
          
           struct direction
                {
                    public int x;
                    public int y;
                };
                
                static direction[] directions = {
                                           new direction(){x = 1, y = 0},
                                           new direction(){x = 0, y = 1},
                                           new direction(){x = -1, y = 0},
                                           new direction(){x = 0, y = -1}
        };
        
         static int[,] visitedmap = resetVisitedMap();
    
          
          
                   struct position
            {
                public int row;
                public int col;
            };
    
            const int NOT_VISITED = 0;
            static int[,] map = {
                                    {0, 4, 0, 0, 0}, 
                                    {0, 0, 0, 0, 2},
                                    {0, 0, 0, 0, 0},
                                    {0, 1, 0, 0, 0},
                                    {0, 0, 0, 0, 3}
                                };
    
            static void Main()
            {
                int[] who = new int[]{1,2,3,4};
                position start;
                start.row = 0;
                start.col = 0;
                Console.Write("("+start.row+","+start.col+")");
                //find 1
                foreach(int lookingfor in who){
                        start = bfs(start, map, lookingfor); 
                        Console.Write("->("+start.row+","+start.col+")");
                }
    
            }
    
            static position bfs(position present, int[,] map, int lookingfor)
            {
                position[] poses = new position[]{present};
                bool found = false;
               
               while (!found){
                   foreach (position pos in poses){
                       if (map[pos.row, pos.col] == lookingfor){
                          // Console.Write("------->Success at : ("+pos.row+","+pos.col+")");
                            visitedmap = resetVisitedMap();
                           return pos;
                       }
                   }
                poses = cellsNear(poses);
               }
               
            return present;
            }
            
            static position[] cellsNear(position pos){
                //Console.WriteLine("Looking for cells near (" + pos.row +","+pos.col+")" );
                List<position> result = new List<position>();
                foreach (direction dir in directions){
                    int rowCalculated = pos.row + dir.x;
                    int colCalculated = pos.col + dir.y;
                    if (rowCalculated >= 0 &&
                            colCalculated >= 0 &&
                            rowCalculated < map.GetLength(0) && 
                            colCalculated < map.GetLength(1) &&
                            !visited(rowCalculated,colCalculated)){
                        visitedmap[rowCalculated,colCalculated] = 1;
                        result.Add(new position(){row =rowCalculated, col = colCalculated });
                        //Console.WriteLine("found children cell : ("+rowCalculated+","+colCalculated+")" );
                    }
                }
                //Console.WriteLine("\n");
                return result.ToArray();
            }
             
            static position[] cellsNear(position[] poses){
                List<position> result = new List<position>();
                foreach (position pos in poses){
                    result.AddRange(cellsNear(pos));
                }
                return result.ToArray();
            }
            
            static bool visited(int row, int col)
                {
                    return visitedmap[row, col] == 1;
                }
        static int[,] resetVisitedMap(){
            return  new int[,]{
                                        {0, 0, 0, 0, 0}, 
                                        {0, 0, 0, 0, 0},
                                        {0, 0, 0, 0, 0},
                                        {0, 0, 0, 0, 0},
                                        {0, 0, 0, 0, 0}
                                    };
        }
    }
