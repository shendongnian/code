    public override void ProcessInput(int InputID, Microsoft.SqlServer.Dts.Pipeline.PipelineBuffer Buffer)
        {
            inputBuffer = Buffer;
            BufferColumnIndexes = GetColumnIndexes(InputID);
            base.ProcessInput(InputID, Buffer);
        }
