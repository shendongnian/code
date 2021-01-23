    var _parameters=new ConcurrentQueue<string>();
   ....
    public void CopyParameters()
    {
         foreach (var parameter in currentRobot.GetParametersProvider().GetParameters())
         {
                _parameters.Enqueue(parameter.PropertyName);
         }
    }
