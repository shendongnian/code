    public class ChickenAI : CreatureAI
    {
        public ChickenAI(GameServer theServer) :
            base(theServer)
        {
            // Do ChickenAI construction
        }
        protected override void IdleEventHandler(object theServer, EventArgs args)
        {
            // Do ChickenAI Idle actions
        }
        protected override void AggroEventHandler(object theServer, EventArgs args)
        {
            // Do ChickenAI Aggro actions
        }
    }
