    public void SetMainCanvasWidth(double size)
    {
        Width = Math.Max(2, size); // that line was evil. removed it and it runs
        MainCanvas.Width = Math.Max(2, size);
    }
