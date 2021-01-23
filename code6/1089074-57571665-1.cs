    public void Input0_ProcessInputRow(Input0ByIndexBuffer Row)
    {
        //do your code
    }
    public override void ProcessInput(int InputID, string InputName, PipelineBuffer Buffer, OutputNameMap OutputMap)
    {
        if (InputName.Equals(@"Input 0", StringComparison.Ordinal))
        {
            Input0_ProcessInput(new Input0ByIndexBuffer(Buffer, GetColumnIndexes(InputID), OutputMap));
        }
    }
    public  void Input0_ProcessInput(Input0ByIndexBuffer Buffer)
    {
        while (Buffer.NextRow())
        {
            Input0_ProcessInputRow(Buffer);
        }
    }
