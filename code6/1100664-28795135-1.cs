    void Start()
    {
        StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        while (true)
        {
            if (nearPlayer)
                yield return StartCoroutine(FollowPlayer());
            else
                yield return StartCoroutine(MoveAround());
        }
    }
