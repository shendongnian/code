    static void Main(string[] args)
        {
            string testStr = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
            //split testStr into substrings representing each edge
            string[] edges = testStr.Split(", ".ToCharArray());
            char[] cEdge;
            foreach (string edge in edges)
            {
                Console.Write(edge + "\n");
                cEdge = edge.ToCharArray();
                char cost = new char();
                if(cEdge.Length > 0)
                { 
                    cost = cEdge[0]; // what out of bounds?
                }
                Console.Write(cost);
            }
            Console.Read();
        }
