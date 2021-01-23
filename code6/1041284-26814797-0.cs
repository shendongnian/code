    public static void Main()
            {
                string testStr = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
                //split testStr into substrings representing each edge
                string[] temp = { ", " };
                string[] edges = testStr.Split(temp, StringSplitOptions.RemoveEmptyEntries);
    
                foreach (string edge in edges)
                {
                    Console.Write(edge + "\n");
                    char[] cEdge = edge.ToCharArray();
                    char cost = cEdge[cEdge.Length - 1]; // what out of bounds?
                    Console.Write(cost);
                }
            }
