    public class Game
    {
        private GameState _state = new GameState();
        private BulletUpdater _bulletUpdater = new BulletUpdater();
        public void Update()
        {
            _bulletUpdater.UpdatePoints(_state);
            // Points have now been modified by another class, even though a Point is a struct.
        }
    }
    public class BulletUpdater
    {
        public void UpdatePoints(GameState state)
        {
            for (int i = 0; i < state.BulletPoints.Count; i++)
            {
                Point p = state.BulletPoints[i];
                state.BulletPoints[i] = new Point(p.X + 1, p.Y + 1);
            }
        }
    }
