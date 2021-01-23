    private static void OnExceptionResult(ExamData data, ExamResult result)
    {
        //save the result, send notification, log results...
        Console.WriteLine(@"Student: {0} achieve score: {1}", data.StudentName, result.Grade);
    }
    private static void OnResult(ExamData data, ExamResult result)
    {
        //save results
        //Console.WriteLine(@"Student: {0} achieve score: {1}", data.StudentName, result.Grade);
    }
    static void Main(string[] args)
    {
        var gradingSystem = new GradingSystem();
        gradingSystem.ExceptionalResultFound += OnExceptionResult;
        gradingSystem.ResultFound+= OnResult;
        for (var i=0; i < 100; i++)
        {
            gradingSystem.EvaluateAsync(new ExamData {StudentName = String.Format("Student #{0}", i)});
        }
            
        Console.ReadKey();
    }
