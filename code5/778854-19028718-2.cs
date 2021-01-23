    public interface ToolAffected {
        
        public void toolUsedOnMe(Tool tool, PickingResult pickingResult,Mob toolUser);
        public void toolUsedOnMe(BlockTool tool, PickingResult pickingResult,Mob toolUser);
        //use polymorphism for more detailed blocks
    }
