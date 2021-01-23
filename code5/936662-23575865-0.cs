    // Stores the frames coming from different threads.
    ConcurrentQueue<byte[]> _queue = new ConcurrentQueue<byte[]>();
    // Begins recording.
    public void Start()
    {
        if (!IsRecording)
        {
            IsRecording = true;
        }
        Task.Run(() =>
        {
            while (IsRecording || _queue.Count > 0)
            {
                byte[] pixels;
                if (_queue.TryDequeue(out pixels))
                {
                    RecordBitmap(pixels);
                }
            }
        });
    }
    // Stops recording.
    public void Stop()
    {
        if (IsRecording)
        {
            IsRecording = false;
        }
    }
    // Updates the frames (called from FrameArrived).
    public void Update(byte[] pixels)
    {
        _queue.Enqueue(pixels);
    }
