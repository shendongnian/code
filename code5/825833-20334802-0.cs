    private float _RawLerp;
    private float _Lerp;
    public float _Speed;
    public transform _Source;
    public transform _Target;
    private transform _TransformCache; // the transform for my game object, set in the Awake method
    public void Update()
    {
        _RawLerp += Time.deltaTime * _Speed;
         _Lerp = Mathf.Min(_RawLerp, 1); 
       _TransformCache.rotation = Quaternion.Slerp(
             _Source.TargetRotation(),
             _Target.TargetRotation(), 
             _Lerp);
    }
