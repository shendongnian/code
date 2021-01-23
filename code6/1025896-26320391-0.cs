    if(spawnTimer > spawnInterval && enemies.Count()<enemyLimit){
       enemies.add(new Enemy([rectangle of spawn location and image size]);
       spawnTimer = 0;
    }
    for(int i=0; i<enemies.Count();i++){
       if(enemies[i].defeated){  
       enemies.Remove(enemies[i]);
    }
    spawnTimer+=gameTime.ElapsedGameTime.TotalSeconds;
    
