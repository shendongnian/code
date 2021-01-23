    // Part of unity - an internal class that you wouldn't see
    public class UnityInternalGameEngineClass
    {
       private void OnEngineStartup()
       {
            DiscoverBehaviors();
       }
    
       private void DiscoverBehaviours() 
       {
          foreach(Type t in Assembly.GetExecutingAssembly().GetTypes().Where(x=>x.IsSubclassOf(typeof(MonoBehavior)))
          {
              // Find method
              MethodInfo m = t.GetMethod("Start");
              delegateCachingSystem.Add(m.CreateDelegate(blahblah));
          }
       }
       private void GameStart() 
       {
         // Loop though all behaviors and start them
       }
       private void GameUpdate()
       {
         // Loop though all behaviors and update them
       }
    }
