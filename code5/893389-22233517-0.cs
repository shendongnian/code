    // You will actually need to attach a collider (and check the 'IsTrigger' checkbox on it) to your GameObject
    // Then this method will be called whenewer some game object with a collider (e. g. player, npc's, monsters) will enter the trigger of this object
    void OnTriggerEnter(Collider other)
    {
        // Check whether this object was eaten before and if the actor entering our trigger is actually the player
        if (!Eaten && other.tag == "Player")
        {
            // Make shure that we will not get eaten twice
            Eaten = true;
            // Apply some effect to the player that has devoured us
            other.GetComponent<Player>().AddHp(25);
        }
    }
