    public class Spike
    {
        void OnCollisionEnter2D(Collision2D other)
        {
            // Do something with:
            GameController.myOnlyPlayer.ReduceLifeCount();
        }
    }
