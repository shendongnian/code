    enemymanager = new EnemyManager(Background, Dispatcher, keys, Display, 10);
    mastertmr = new System.Windows.Forms.Timer();
    mastertmr.Interval = this.waitTime;
    mastertmr.Tick += new EventHandler(Click);
    mastertmr.Tick += new EventHandler(enemymanager.hi);
    mastertmr.Start();
