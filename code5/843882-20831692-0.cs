    public class Submarine
    {
        public enum AIState
        {
            Attacking = 0,
            Retreating = 1
        }
        public AIState mCurrentAIState { get; set; }
        // # Your fields, properties, constructor, methods here
        public void DecideNextMove()
        {
            if (mCurrentAIState == AIState.Attacking)
            {
                // Decide
            }
            else if (mCurrentAIState == AIState.Retreating)
            {
                // Decide
            }
        }
    }
