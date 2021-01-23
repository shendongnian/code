    public class EngagingState : State<BattleUnit>
    {
        public EngagingState(BattleUnit unit)
            : base(unit)
        {
        }
        
        public override void Handle()
        {
            //  Here you can implement the "engaging" logic for a BattleUnit.
            this.Unit.X = ????;
            this.Unit.Y = ????;        
        }
    }
