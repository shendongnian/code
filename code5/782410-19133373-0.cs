    abstract class AbsGraph
    {
        public string ImageFile { get; protected set; }
        //other properties
    
        public abstract void DrawGraph();
        //other methods
    
        public void CommonMethod()
        { }
        //other common method
    }
    
    class Graph1 : AbsGraph
    {
        public override void DrawGraph()
        {
            //do graph specific task
        }
    }
    
    class Graph2 : AbsGraph
    {
        public override void DrawGraph()
        {
            //do graph specific task
        }
    }
    
    class Graph3 : AbsGraph
    {
        public override void DrawGraph()
        {
            //do graph specific task
        }
    }
