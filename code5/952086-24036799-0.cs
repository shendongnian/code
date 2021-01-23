    Dictionary<string, Action>actions = new Dictionary<string, Action>();
    void Init(){
      actions.Add("Init" ,AlgoInit1);
      actions.Add("Body" ,AlgoBody6);
      actions.Add("End" ,AlgoEnd3);
    }
    void Do(string action){
       actions[action]();
    }
    private static void AlgoInit1(){
        throw new NotImplementedException();
    }
