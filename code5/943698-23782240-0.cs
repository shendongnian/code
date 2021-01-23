	//[OperationContractAttribute]
        public int[] GetUnitPosition(string guid)
        {
            int x = 0, y = 0;
            //calculate something..
            //then Log this information 
            Logger.Info("position", guid, x, y); //save this into any DB
            return new[] {x, y};
        }
