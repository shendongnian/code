    interface ITool {
        DoJob();
    }
    class Manager {
        public Manager(IEnumberable<ITool> tools);
        
        public AddTool(ITool tool);
    } 
