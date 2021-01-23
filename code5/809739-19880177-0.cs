       static void Main(string[] args)
        {
            var route1 = new List<int> { 1, 2, 3 };
            var route2 = new List<int> { 6, 7, 8 };
            var route3 = new List<int> { 3, 7, 13 };
            var route4 = new List<int> { 8, 9, 10 };
            List<List<int>> routeList = new List<List<int>>();
            routeList.Add(route1);
            routeList.Add(route2);
            routeList.Add(route3);
            routeList.Add(route4);
            int start = 3;
            int end = 9;
            var vistedRoutes = new List<List<int>>();
            foreach(var route in routeList.FindAll(r => r.Contains(start)))
            {
                vistedRoutes.Add(route);
                routeList.Remove(route);
                FindPath(vistedRoutes, routeList, start, end);
                if (vistedRoutes.Last().Contains(end))
                {
                    break;
                }
            }
            Console.WriteLine("done");
        }
        static void FindPath(List<List<int>> visitedRoutes, List<List<int>> remainingRoutes, int start, int end)
        {
            if (visitedRoutes.Last().Contains(end))
            {
                return;
            }
            for (int i = 0; i < remainingRoutes.Count; i++ )
            {
                var route = remainingRoutes[i];
                foreach (var point in route)
                {
                    if (visitedRoutes.Last().Contains(point))
                    {
                        visitedRoutes.Add(route);
                        var newRemainingRoutes = new List<List<int>>(remainingRoutes);
                        newRemainingRoutes.Remove(route);
                        FindPath(visitedRoutes, newRemainingRoutes, start, end);
                        if (visitedRoutes.Last().Contains(end))
                        {
                            return;
                        }
                        else
                        {
                            visitedRoutes.Remove(route);
                        }
                    }
                }
            }
        }
