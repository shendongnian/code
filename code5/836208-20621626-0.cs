    public int[] ChoiceIDs
    { 
        get {
         return this.Choices.Select(x => x.Id).ToArray();
        }
    }
