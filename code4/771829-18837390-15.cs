    public StackFrame.ctor(int skipFrames, bool fNeedFileInfo)
    {
        this.InitMembers();
        this.BuildStackFrame(skipFrames, fNeedFileInfo);
    }
    
    private void StackFrame.BuildStackFrame(int skipFrames, bool fNeedFileInfo)
    {
        StackFrameHelper sfh = new StackFrameHelper(fNeedFileInfo, null);
        StackTrace.GetStackFramesInternal(sfh, 0, null);
        int numberOfFrames = sfh.GetNumberOfFrames();
        skipFrames += StackTrace.CalculateFramesToSkip(sfh, numberOfFrames);
        if ((numberOfFrames - skipFrames) > 0)
        {
            this.method = sfh.GetMethodBase(skipFrames);
            this.offset = sfh.GetOffset(skipFrames);
            this.ILOffset = sfh.GetILOffset(skipFrames);
            if (fNeedFileInfo)
            {
                this.strFileName = sfh.GetFilename(skipFrames);
                this.iLineNumber = sfh.GetLineNumber(skipFrames);
                this.iColumnNumber = sfh.GetColumnNumber(skipFrames);
            }
        }
    } 
    
    public StackTrace.ctor()
    {
        this.m_iNumOfFrames = 0;
        this.m_iMethodsToSkip = 0;
        this.CaptureStackTrace(0, false, null, null);
    }
    
    private void StackTrace.CaptureStackTrace(int iSkip, bool fNeedFileInfo, Thread targetThread, Exception e)
    {
        this.m_iMethodsToSkip += iSkip;
        StackFrameHelper sfh = new StackFrameHelper(fNeedFileInfo, targetThread);
        GetStackFramesInternal(sfh, 0, e);
        this.m_iNumOfFrames = sfh.GetNumberOfFrames();
        if (this.m_iMethodsToSkip > this.m_iNumOfFrames)
        {
            this.m_iMethodsToSkip = this.m_iNumOfFrames;
        }
        if (this.m_iNumOfFrames != 0)
        {
            this.frames = new StackFrame[this.m_iNumOfFrames];
            for (int i = 0; i < this.m_iNumOfFrames; i++)
            {
                bool flag = true;
                bool flag2 = true;
                StackFrame frame = new StackFrame(flag, flag2);
                frame.SetMethodBase(sfh.GetMethodBase(i));
                frame.SetOffset(sfh.GetOffset(i));
                frame.SetILOffset(sfh.GetILOffset(i));
                frame.SetIsLastFrameFromForeignExceptionStackTrace(sfh.IsLastFrameFromForeignExceptionStackTrace(i));
                if (fNeedFileInfo)
                {
                    frame.SetFileName(sfh.GetFilename(i));
                    frame.SetLineNumber(sfh.GetLineNumber(i));
                    frame.SetColumnNumber(sfh.GetColumnNumber(i));
                }
                this.frames[i] = frame;
            }
            if (e == null)
            {
                this.m_iMethodsToSkip += CalculateFramesToSkip(sfh, this.m_iNumOfFrames);
            }
            this.m_iNumOfFrames -= this.m_iMethodsToSkip;
            if (this.m_iNumOfFrames < 0)
            {
                this.m_iNumOfFrames = 0;
            }
        }
        else
        {
            this.frames = null;
        }
    }
    
    public virtual StackFrame StackTrace.GetFrame(int index)
    {
        if (((this.frames != null) && (index < this.m_iNumOfFrames)) && (index >= 0))
        {
            return this.frames[index + this.m_iMethodsToSkip];
        }
        return null;
    }
