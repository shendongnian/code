            List<Action> act = new List<Action> { () => TestParallel1(), 
                                              () => TestParallel1() };
            Parallel.ForEach(act, (a, state) =>
            {
                try
                {
                    a.Invoke();
                }
                catch (MyException ae)
                {
                    state.Stop();
                }
            });
