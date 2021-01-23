    public class InstructionCycles
    {
        private readonly ConcurrentDictionary<Action, string> _dictActionResults = new ConcurrentDictionary<Action, string>();
        private void fetch()
        {
            // do something and store the result in the dictionary
            _dictActionResults[fetch] = "FetchResult";
        }
        private void decode()
        {
            // do something and store the result in the dictionary
            _dictActionResults[decode] = "DecodeResult";
        }
        private void execute()
        {
            // do something and store the result in the dictionary
            _dictActionResults[execute] = "ExecuteResult";
        }
        private void writeBack()
        {
            // do something and store the result in the dictionary
            _dictActionResults[writeBack] = "WriteBackResult";
        }
        public static void nextInstruction()
        {
            InstructionCycles instrCycles = new InstructionCycles();
            Action[] actions = 
            {
                instrCycles.fetch,
                instrCycles.decode,
                instrCycles.execute,
                instrCycles.writeBack
            };
            Parallel.Invoke(actions);
            // output the results in sequential order
            foreach (Action a in actions)
            {
                Console.Out.WriteLine(instrCycles._dictActionResults[a]);
            }
        }
    }
