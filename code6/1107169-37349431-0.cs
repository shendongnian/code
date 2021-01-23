        public delegate string DelegateAction(params string[] args);
        public Dictionary<string, DelegateAction> Actions = new Dictionary<string, DelegateAction>();
    
        public void InitializeDictionary()
        {
          Actions.Add("walk",Move);
        }
    
        
        public string Move(params string[] args)
        {
          if (args.Length > 0)
          {
            if (!string.IsNullOrWhiteSpace(args[0]))
            {
              switch (args[0].ToLower())
              {
                case "forward":
                  return "You move forward at a leisurely pace";
                case "right":
                case "left":
                case "backward":
                  throw new NotImplementedException("Still need to set these up");
                default:
                  return "You need to specify a valid direction (forward,backward,right,left).";
              }
            }
          }
          return "You need to specify a direction.";
        }
    
        public string ProcessAction(string action, params string[] args)
        {
          return Actions[action.ToLower()].Invoke(args);
        }
