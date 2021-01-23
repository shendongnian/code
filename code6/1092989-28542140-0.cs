    private static object objectlock = new object();
    private void FixProblem(){
       lock(objectlock)
       {
          if (!_isPaused){
             _isPaused = true;
             // spawn new motherDriver
             _isPaused = false;
          }
       }
    }
