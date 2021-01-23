    public static Task<Point> WhenRightClicked(this UserActivityHook hook)
    {
        var tcs = new TaskCompletionSource<Point>();
        MouseEventHandler handler = null;
        handler = (s, e) =>
        {
            if (e.Clicks > 0 && e.Button == MouseButtons.Right)
            {
                tcs.TrySetResult(new Point(e.X, e.Y));
                hook.OnMouseActivity -= handler;
            }
        };
        hook.OnMouseActivity += handler;
        return tcs.Task;
    }
