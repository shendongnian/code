        public Bullet[] CreateBullets(int amount)
        {
            Bullet[] bullets = new Bullet[amount];
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = Bullet.CreateBullet(); 
            }
            return bullets;
        }
