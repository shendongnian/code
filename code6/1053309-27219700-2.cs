    [Range (0,1)]
    public float appleProbability = 0.4f ;
    [Range (0,1)]
    public float fishProbability = 0.2f ;
    [Range (0,1)]
    public float cheeseProbability = 0.10f ;
    [Range (0,1)]
    public float poopProbability = 0.14f ;
    [Range (0,1)]
    public float bombProbability = 0.14f ;
    [Range (0,1)]
    public float starProbability = 0.02f ;
    private float[] probs;
    MyClass()
    {
        probs = new float[] {
                           appleProbability, 
                           fishProbability, 
                           cheeseProbability, 
                           poopProbability, 
                           bombProbability, 
                           starProbability};
    }
