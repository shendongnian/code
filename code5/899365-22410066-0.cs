    protected override void OnResize(EventArgs e) {
        if (Cursor.Current == Cursors.SizeNWSE) {
            Console.WriteLine("lower right corner");
        }
        base.OnResize(e);
    }
