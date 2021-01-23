    public class Game
    {
        private const int InitialLifesCount = 100;
        public Game()
        {
             EnemyLifes = InitialLifesCount;
        }
        public int EnemyLifes { get; set; }
        public AttackEnemy()
        {
            EnemyLifes--;
        }
    }
