     public bool Enable { get;set;}
     private bool _initialized = false;
     void Update(){
         if (!Enable) return;
         Init();
         OnUpdate();
     }
     protected virtual void OnUpdate()
     {
     // filled in by user script
     }
     private void Init()
     {
     if (_initialized) return;
     OnInit();
     _initialized = true;
     }
     protected virtual void OnInit()
     {
     // filled in by user script
     }
