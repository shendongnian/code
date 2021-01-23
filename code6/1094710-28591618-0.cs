    public Func<int> getProc(int id)
    {
        switch (id)
        {
            case 1:
                return () => proc1tasks;
            case 2:
                return () => proc2tasks;
        }
    }
