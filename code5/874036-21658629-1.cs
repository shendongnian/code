    private class Enemy
    {
        public int position;
    }
    private List<Enemy> enemyList = new List<Enemy>();
    private void timer1_Tick(object sender, EventArgs e)
    {
        enemyList.Add(new Enemy());  
    }
    private void timer2_Tick(object sender, EventArgs e)
    {
        foreach(Enemy enemy in enemyList)
        {
            enemy.position++;
        }
    }
