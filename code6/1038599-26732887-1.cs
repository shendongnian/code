    IEnumerator Start()
    {
        var getVersion = gameObject.GetComponent<VersionChecker>();
        if (getVersion != null)
        {
            yield return StartCoroutine(getVersion.GetVersion());
        }
        if(!isExit)
            yield return StartCoroutine (BeginningAnimation());
        else
            yield return StartCoroutine (EndAnimation());
    }
