    private void MyFunction(int groupID, Action a, Action b, Action c)
    {
        switch (groupID)
        {
            case 0:
                a();
                break;
            case 1:
                b();
                break;
            case 2:
                c();
                break;
        }
    }
