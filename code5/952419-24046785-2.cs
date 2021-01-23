    enum ReplaceSegTuvState
    {
        Idle,
        InsideSEG
    }
    static void ReplaceSegTuv(StreamReader input, StreamWriter output)
    {
        ReplaceSegTuvState state = ReplaceSegTuvState.Idle;
        StringBuilder segBuffer = new StringBuilder();
        while (!input.EndOfStream)
        {
            char ch = (char)input.Read();
            switch (state)
            {
                case ReplaceSegTuvState.Idle:
                    if (ch == '<')
                    {
                        char[] buffer = new char[4];
                        int bufferActualLength = input.ReadBlock(buffer, 0, buffer.Length);
                        output.Write('<');
                        output.Write(buffer, 0, bufferActualLength);
                        if (bufferActualLength == buffer.Length && "seg>".SequenceEqual(buffer))
                        {
                            segBuffer.Clear();
                            state = ReplaceSegTuvState.InsideSEG;
                        }
                    }
                    else
                        output.Write(ch);
                    break;
                case ReplaceSegTuvState.InsideSEG:
                    if (ch == '<')
                    {
                        char[] buffer = new char[5];
                        int bufferActualLength = input.ReadBlock(buffer, 0, buffer.Length);
                        if (bufferActualLength == buffer.Length && "/tuv>".SequenceEqual(buffer))
                        {
                            output.Write("</seg>");
                            output.Write("</tuv>");
                            state = ReplaceSegTuvState.Idle;
                        }
                        else
                        {
                            output.Write(segBuffer.ToString());
                            output.Write('<');
                            output.Write(buffer, 0, bufferActualLength);
                            state = ReplaceSegTuvState.Idle;
                        }
                    }
                    else if (!char.IsWhiteSpace(ch))
                    {
                        output.Write(segBuffer.ToString());
                        output.Write(ch);
                        state = ReplaceSegTuvState.Idle;
                    }
                    else
                        segBuffer.Append(ch);
                    break;
            }
        }
    }
