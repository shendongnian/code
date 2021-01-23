    Variables.GetMatrix();
    int ThreadNumber = Environment.ProcessorCount / 2;
    int SS = Variables.PopSize / ThreadNumber;
    //GeneticAlgorithm GA = new GeneticAlgorithm();
    Stopwatch stopwatch = new Stopwatch(), st = new Stopwatch(), st1 = new Stopwatch();
    List<WaitHandle> WaitList = new List<WaitHandle>();
    //List<Task> TaskList = new List<Task>();
    GeneticAlgorithm[] SubPop = new GeneticAlgorithm[ThreadNumber];
    //Task t;
    ThreadVariables Instance = new ThreadVariables();
    stopwatch.Start();
    st.Start();
    PopSettings();
    InitialPopulation();
    st.Stop();
    //lots of attributions...
    int SPos = 0, EPos = SS;
    for (int i = 0; i < ThreadNumber; i++)
    {
        int temp = i, StartPos = SPos, EndPos = EPos;
        ManualResetEvent wg = new ManualResetEvent(false);
        WaitList.Add(wg);
        ThreadPool.QueueUserWorkItem((unused) =>
        {
            SubPop[temp] = new GeneticAlgorithm(Population, NumSeq, SeqSize, MaxOffset, PopFit, Child, Instance, StartPos, EndPos);
            SubPop[temp].RunGA();
            SubPop[temp].ShowPopulation();
            wg.Set();
        });
                
        SPos = EPos;
        EPos += SS;
    }
    ManualResetEvent.WaitAll(WaitList.ToArray());
    double BestFit = SubPop[0].BestSol;
    string BestAlign = SubPop[0].TV.Debug;
    for (int i = 1; i < ThreadNumber; i++)
    {
        if (BestFit < SubPop[i].BestSol)
        {
            BestFit = SubPop[i].BestSol;
            BestAlign = SubPop[i].TV.Debug;
            Variables.ResSave = SubPop[i].TV.ResSave;
            Variables.NumSeq = SubPop[i].TV.NumSeq;
        }
    }
