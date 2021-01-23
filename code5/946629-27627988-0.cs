	public class EnemyModel : IEnemyModel
	{
		// int is the id of the enemy's instance id in the view i.e. view.GetInstanceID()
		public IDictionary<int,Enemy> enemyDict {get;set;}
		
		public EnemyModel ()
		{
			enemyDict = new Dictionary<int,Enemy>();
		}
	}
	public class Enemy
	{
		public bool  isDangerous = false;
		public float health = 1;
	}
