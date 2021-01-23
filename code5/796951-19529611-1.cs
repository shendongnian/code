    class MakeOwnQuestion
    {
        List<Tuple<string, string>> makequestion = new List<Tuple<string, string>>();
    
        public void MakeQuestion(string question, string answer, int index)
        {
            makequestion.Add(Tuple.Create(question, answer));
        }
    }
