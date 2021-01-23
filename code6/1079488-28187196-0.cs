     var sw = Stopwatch.StartNew();
     var rx = new Subject<int>();
     var subscriberADone = new Subject<Unit>();
     var subscriberBDone = new Subject<Unit>();
     var bothSubscribersDone = subscriberADone.Zip(subscriberBDone, (_, __) => Unit.Default);
     var lockStepInput = rx.Zip(bothSubscribersDone.StartWith(Unit.Default), (i, _) => i);
     lockStepInput.ObserveOn(ThreadPoolScheduler.Instance)
         .Subscribe(o =>
         {
             // Fast Subscriber A. Takes 20 milliseconds.
             Thread.Sleep(TimeSpan.FromMilliseconds(20));
             Console.Write("Subscriber A: {0} (thread {1}). Time: {2} milliseconds.\n", o, Thread.CurrentThread.ManagedThreadId.ToString("").PadLeft(2), sw.ElapsedMilliseconds);
             subscriberADone.OnNext(Unit.Default);
         });
     lockStepInput.ObserveOn(ThreadPoolScheduler.Instance)
         .Subscribe(o =>
         {
             // Slow Subscriber B. Takes 500 milliseconds.
             Thread.Sleep(TimeSpan.FromMilliseconds(500));
             Console.Write("Subscriber B: {0} (thread {1}). Time: {2} milliseconds.\n", o, Thread.CurrentThread.ManagedThreadId.ToString("").PadLeft(2), sw.ElapsedMilliseconds);
             subscriberBDone.OnNext(Unit.Default);
         });
     for (int j = 0; j < 5; j++)
     {
         int j1 = j;
         rx.OnNext(j1);
         Console.Write("Push: {0} (thread {1})\n", j, Thread.CurrentThread.ManagedThreadId);
     }
