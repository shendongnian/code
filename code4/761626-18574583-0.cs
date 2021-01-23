    try {
        Submission<object> submission = engine.CompileSubmission<object>(s, session);
        object result = submission.Execute();
    }
    catch (CompilationErrorException e) {
       Console.WriteLine(e.Diagnostics.Select(d => d.ToString()));
    }
    catch (Exception e) {
       Console.WriteLine(e.ToString());
    }
