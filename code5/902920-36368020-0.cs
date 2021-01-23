    public IEnumerator ThisWillBeExecutedOnTheMainThread() {
        Debug.Log ("This is executed from the main thread");
        yield return null;
    }
    public void ExampleMainThreadCall() {
        UnityMainThreadDispatcher.Instance().Enqueue(ThisWillBeExecutedOnTheMainThread());
    }
