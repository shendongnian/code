     class Example: MonoBehavior
     {
         public GameObject _TargetCharacter;
         private Transform _cachedTransform;
         private Animator  _cachedAnimator;
         void Awake()
         {
          if (_TargetCharacter != null)
          {
              _cachedTransform = _TargetCharacter.transform;
              _cachedAnimator = _TargetCharacter.GetComponent<Animator>();
           }
         }
         void Update()
         {
             DoSomething (_cachedTransform, _cachedAnimator);
         }
     } 
