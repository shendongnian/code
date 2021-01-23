    public void DoLeftMouseClickDown(int x int y)
    {
        mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
    }
    public void DoLeftMouseClickUp(int x int y)
    {
        mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
    }
    public void DoLeftMouseClickDown(int x int y)
    {
        mouse_event(MOUSEEVENTF_RIGHTDOWN , x, y, 0, 0);
    }
    public void DoLeftMouseClickUp(int x int y)
    {
        mouse_event(MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
    }
