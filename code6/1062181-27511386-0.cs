    void Start () {
        destinationLoc = target1.position;
        agent = GetComponent<NavMeshAgent> ();
        agent.SetDestination (destinationLoc);
    }
    
    // Update is called once per frame
    void Update () {
        Debug.Log (agent.remainingDistance);
        if (agent.remainingDistance <= 1.0) {
            Debug.Log ("It gets here.");
            int rr = Random.Range(1,30);
            Debug.Log( "Random value: " + rr );
    
            if (rr == 1) {
                destinationLoc = target1.position;
                Debug.Log ("Changed to 1.");
            } else {
                destinationLoc = target2.position;
                Debug.Log("Changed to 2");
            }
    
            // Set destination AFTER it has been changed
            agent.SetDestination (destinationLoc);
    
        }
    }
