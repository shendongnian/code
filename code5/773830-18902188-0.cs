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
    
    
    
             class Position
            {
                public int row;
                public int col;
                public Position  parent;
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
                Position start = new Position();
                start.row = 0;
                start.col = 0;
                start.parent = null;
                Console.Write("("+start.row+","+start.col+")");
                //find 1
                foreach(int lookingfor in who){
                        start = bfs(start, map, lookingfor); 
                        Console.Write("->("+start.row+","+start.col+")");
                }
                
                Console.Write("\n Full path :\n");
                string path = "";
                while (start != null){
                    path = "->("+ start.row+","+start.col+")"+path;
                    start = start.parent;
                }
                Console.Write(path);
            }
    
            static Position bfs(Position present, int[,] map, int lookingfor)
            {
                Position[] poses = new Position[]{present};
                bool found = false;
    
               while (!found){
                   foreach (Position pos in poses){
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
    
            static Position[] cellsNear(Position pos){
                //Console.WriteLine("Looking for cells near (" + pos.row +","+pos.col+")" );
                List<Position> result = new List<Position>();
                foreach (direction dir in directions){
                    int rowCalculated = pos.row + dir.x;
                    int colCalculated = pos.col + dir.y;
                    if (rowCalculated >= 0 &&
                            colCalculated >= 0 &&
                            rowCalculated < map.GetLength(0) && 
                            colCalculated < map.GetLength(1) &&
                            !visited(rowCalculated,colCalculated)){
                        visitedmap[rowCalculated,colCalculated] = 1;
                        Position posPath = new Position();
                        posPath.col = colCalculated;
                        posPath.row = rowCalculated;
                        posPath.parent = pos;
                        result.Add(posPath);
                        //Console.WriteLine("found children cell : ("+rowCalculated+","+colCalculated+")" );
                    }
                }
                //Console.WriteLine("\n");
                return result.ToArray();
            }
    
            static Position[] cellsNear(Position[] poses){
                List<Position> result = new List<Position>();
                foreach (Position pos in poses){
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
