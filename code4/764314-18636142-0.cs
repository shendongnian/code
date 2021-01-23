    static void Main(string[] args)
    {
    TrackingObject oTracking = new TrackingObject();
    ProjectInfo pInfo = new ProjectInfo();
    oTracking.OrderId = 1;
    oTracking.ProjectCount = 1;
    pInfo.ProjectId = 1;
    pInfo.ProjectType = "CANVAS";
    pInfo.ImageCount = 1;
    oTracking.Projects = new List<ProjectInfo>();
    oTracking.Projects.Add(pInfo);
    Console.WriteLine(oTracking.Projects.Count);
    Console.ReadLine();     
    }
