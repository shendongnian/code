    bool b;
    b = false; // Do something before the block.
    using (new MyUsing(delegate { b = true; })) // Do something after the block.
    {
        // Do Things.
    }
