    internal class Input : IInput
    {
      private readonly IDictionary<Keys, Tuple<Action<Directions>, Directions>> keyBindings;
      public void BindKey( Keys key, Tuple<Action<Directions>, Directions> action)
      {
        keyBindings.Add( key, action );
      }
      public void Process()
      {
        // update keyboard state...            
        foreach ( var binding in keyBindings )
        {
            if ( keyboard.IsKeyDown( binding.Key )
            {
                binding.Value.Item1(binding.Value.Item2);
            }
        }
      }
    }
