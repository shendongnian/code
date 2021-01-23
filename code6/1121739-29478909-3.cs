    public static Queue<Point> queue=new Queue<Point>();
            
            public SolveMaze(int[,] array,int staX,int staY,int finX,int finY)
            {
                //sets Destination as 9
                arr = array;
                XMAX = array.GetLength(0);
                YMAX = array.GetLength(1);
                finishY = finX; finishX = finY; startY = staX; startX = staY;
                solvedarray = new int[XMAX, YMAX];
            }
    
            public static List<int> nodelist=new List<int>();
    
            public void AddPointToQueueIfOpenAndNotAlreadyPresent(Point p,int direction)
            {
                if (nodelist.Contains(XMAX * p.y + p.x))
                    return;
                else
                {
                    switch(direction){
                    case 1:
                        //north
                        if (IsOpen(p.x, p.y - 1))
                        {
                            arr[p.x, p.y] = 1;
                            queue.Enqueue(new Point(p.x, p.y - 1, p));
                            nodelist.Add(XMAX * (p.y - 1) + p.x);
                        }
                        break;
                    case 0:
                        //east
                        if (IsOpen(p.x + 1, p.y))
                        {
                            arr[p.x, p.y] = 1;
                            queue.Enqueue(new Point(p.x + 1, p.y, p));
                            nodelist.Add(XMAX * (p.y) + p.x + 1);
                        }
                        break;
                    case 3:
                        //south
                        if (IsOpen(p.x, p.y + 1))
                        {
                            arr[p.x, p.y] = 1;
                            queue.Enqueue(new Point(p.x, p.y +1, p));
                            nodelist.Add(XMAX * (p.y + 1) + p.x);
                        }
                        break;
                    case 2:
                        //west
                        if (IsOpen(p.x - 1, p.y))
                        {
                            arr[p.x, p.y] = 1;
                            queue.Enqueue(new Point(p.x - 1, p.y, p));
                            nodelist.Add(XMAX * (p.y) + p.x-1);
                        }
                        break;                    }
                }
            }
    
            public Point GetFinalPath(int x, int y) {
                if (arr[finishX, finishY] == 0)
                    arr[finishX, finishY] = 9;
                else
                    return null;
    
                    queue.Enqueue(new Point(x, y, null));
                    nodelist.Add(XMAX * y + x);
    
            while(queue.Count>0) {
                Point p = queue.Dequeue();
                nodelist.Remove(p.y * XMAX + p.x);
    
                if (arr[p.x,p.y] == 9) {
                    Console.WriteLine("Exit is reached!");
                    return p;
                }
    
                for (int i = 0; i < 4; i++)
                {
                    AddPointToQueueIfOpenAndNotAlreadyPresent(p, i);
                }
            }
            return null;
        }
    
    
            public static bool IsOpen(int x, int y)
            {
                //BOUND CHECKING
                if ((x >= 0 && x < XMAX) && (y >= 0 && y < YMAX) && (arr[x,y] == 0 || arr[x,y] == 9))
                {
                    return true;
                }
                return false;
            }
    
    
                public int[,] SolutionMaze()
                {
                    Point p = GetFinalPath(startX, startY);
                    if(p!=null)
                    while (p.getParent() != null)
                    {
                        solvedarray[p.x, p.y] = 9;
                        p = p.getParent();
                    }
                    return solvedarray;
                }
        }
    
             public class Point
            {
               public int x;
               public int y;
                Point parent;
    
                public Point(int x, int y, Point parent)
                {
                    this.x = x;
                    this.y = y;
                    this.parent = parent;
                }
    
                public Point getParent()
                {
                    return this.parent;
                }
    
            }       
