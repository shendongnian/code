    enum TruncateSegState
    {
        Idle,
        TagStart,
        TagStartS,
        TagStartSE,
        TagStartSEG,
        TagSEG
    }
    static void TruncateSeg(StreamReader input, StreamWriter output)
    {
        TruncateSegState state = TruncateSegState.Idle;
        while (!input.EndOfStream)
        {
            char ch = (char)input.Read();
            switch (state)
            {
                case TruncateSegState.Idle:
                    if (ch == '<')
                        state = TruncateSegState.TagStart;
                    output.Write(ch);
                    break;
                case TruncateSegState.TagStart:
                    if (ch == 's')
                        state = TruncateSegState.TagStartS;
                    else
                        state = TruncateSegState.Idle;
                    output.Write(ch);
                    break;
                case TruncateSegState.TagStartS:
                    if (ch == 'e')
                        state = TruncateSegState.TagStartSE;
                    else
                        state = TruncateSegState.Idle;
                    output.Write(ch);
                    break;
                case TruncateSegState.TagStartSE:
                    if (ch == 'g')
                        state = TruncateSegState.TagStartSEG;
                    else
                        state = TruncateSegState.Idle;
                    output.Write(ch);
                    break;
                case TruncateSegState.TagStartSEG:
                    if (char.IsWhiteSpace(ch))
                        state = TruncateSegState.TagSEG;
                    else
                    {
                        state = TruncateSegState.Idle;
                        output.Write(ch);
                    }
                    break;
                case TruncateSegState.TagSEG:
                    if (ch == '>')
                    {
                        state = TruncateSegState.Idle;
                        output.Write(ch);
                    }
                    break;
            }
        }
    }
