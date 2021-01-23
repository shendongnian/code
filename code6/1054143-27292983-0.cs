    while (!exit)
    {
        var msg = WaitForMessage(); // Blocks until message arrives
        switch (msg.Type)
        {
            case Message.MouseMove: OnMouseMove(msg); break;
            case Message.Paint: OnPaint(msg); break;
            ...
        }
    }
