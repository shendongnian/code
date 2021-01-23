    private static void Vector3Test()
    {
        Vector3 v1 = new Vector3(0, 0, 0);
                
        ChangeVector(ref v1);
                
        Debug.Log(v1);
    }
    private static void ChangeVector(ref Vector3 vector)
    {
        vector.x = 10;
    }
