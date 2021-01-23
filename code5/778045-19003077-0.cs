    static IEnumerable LogValues(IEnumerable enumerable)
    {
        foreach (var value in enumerable)
        {
            Debug.Log(value.ToString());
            yield return value;
        }
    }
    // ..
    // Keep getjsonroomtype1 untouched
    // ..
    public void getTypeRoomb1(string buildingNUM)
    {
        StartCoroutine(LogValues(getjsonroomtype1(buildingNUM)));
    }
