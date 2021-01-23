    class IVoidFloatCallback
    {
    public:
       virtual ~IVoidFloatCallback() { }
       virtual void VoidFloatCallback(float elapsedTime) = 0;
    };
    class Game
    {
    public:
        std::vector<IVoidFloatCallback*> mOnEveryUpdate;
        std::vector<IVoidFloatCallback*> mOnNextUpdate;
        void Update(float gameTime)
        {
           for ( auto& update : mOnNextUpdate )
           {
              update->VoidFloatCallback(gameTime);
           }
           mOnNextUpdate.clear();
           for ( auto& update : mOnEveryUpdate )
           {
               update->VoidFloatCallback(gameTime);
           }
           OnUpdate(gameTime);
        }
    };
    class UpdateMe : public IVoidFloatCallback
    {
    public:
       virtual void VoidFloatCallback(float elapsedTime)
       {
         // Do something
       }
    };
    void InitGame()
    {
        Game g;
        UpdateMe someThing;
        g.mOnEveryUpdate.push_back(&someThing);
        g.Update(1.0f);
    }
