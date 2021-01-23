    public int DecideID() {
        id = 0;
        if (gameLeft >= 1f && timeZone_Zone.zoneAlive == false) {
            id = Random.Range(0, 5);
        }
        return id;
    }
