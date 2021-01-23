    var list = new List<AnswerDetailToClient>();
    list.Add(new AnswerDetailToClient{AnswerUId = 100, Correct = true, Response = false, Text = "Bla bla"});
    list.Add(new AnswerDetailToClient { AnswerUId = 111, Correct = true, Response = false, Text = "Bla bla" });
    list.Add(new AnswerDetailToClient { AnswerUId = 222, Correct = true, Response = false, Text = "Bla bla" });
    list.Add(new AnswerDetailToClient { AnswerUId = 333, Correct = true, Response = false, Text = "Bla bla" });
    list.Add(new AnswerDetailToClient { AnswerUId = 444, Correct = true, Response = false, Text = "Bla bla" });
    list.Add(new AnswerDetailToClient { AnswerUId = 555, Correct = true, Response = false, Text = "Bla bla" });
    
    int i = 0;
    var q = (from t in list
        let x = ++i
        select new
        {
            asnswerId= x,
            correct = t.Correct,
            response = t.Response,
            text = t.Text
        });
    foreach (var l in q)
    {
        Console.WriteLine(l.asnswerId);
    }
    Console.Read();
