    IAsyncEnumerable<string> GetAsyncAnswers()
    {
        return AsyncEnum.Enumerate<string>(async consumer =>
        {
            foreach (var question in GetQuestions())
            {
                string theAnswer = await answeringService.GetAnswer(question);
                await consumer.YieldAsync(theAnswer);
            }
        });
    }
