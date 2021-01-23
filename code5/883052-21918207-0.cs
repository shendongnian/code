    public int BulletCount = 0;
    public enum CombatAIStates
    {
        Firing = 0,
        Reloading = 1,
    }
    CombatAIStates currentState = CombatAIStates.Firing;
    // Update is called once per frame
    void Update () {
        switch (currentState) {
            case CombatAIStates.Firing:
                if (BulletCount < 5) {
                    Debug.Log ("Firing: " + BulletCount);
                    ++BulletCount;
                } else {
                    currentState = CombatAIStates.Reloading;
                    StartCoroutine(Reload ());
                }
                break;
            case CombatAIStates.Reloading:
                // Nothing to do here, Reload() coroutine is handling things.
                // Maybe play a 10 second animation here or twiddle thumbs
                break;
        }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds (10.0f);
        BulletCount = 0;
        //Now update the current combat state
        currentState = CombatAIStates.Firing;		
    }
