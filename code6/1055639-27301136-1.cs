    if(health < maxHealth)
    {
        healing = true;
        health += healthModifier;
    }
    else
    {       
        healing = false;        
    }
    //fix health meter, if above maximum
    if(health > maxHealth)
    {
        health = maxHealth;
    }
