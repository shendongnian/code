    public class Submarine
    {
        public enum AIState
        {
            Attacking = 0,
            Retreating = 1
        }
        public AIState CurrentAIState { get; set; }
        // # Your fields, properties, constructor, methods here
        public void DecideNextMove()
        {
            if (CurrentAIState == AIState.Attacking)
            {
                // Decide
            }
            else if (CurrentAIState == AIState.Retreating)
            {
                // Decide
            }
        }
    }
