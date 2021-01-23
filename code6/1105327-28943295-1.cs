    public virtual void BeginFinallyBlock() 
    {
        if (m_currExcStackCount==0) { 
            throw new NotSupportedException(Environment.GetResourceString("Argument_NotInExceptionBlock"));
        }
        __ExceptionInfo current = m_currExcStack[m_currExcStackCount-1];
        int         state = current.GetCurrentState(); 
        Label       endLabel = current.GetEndLabel();
        int         catchEndAddr = 0; 
        if (state != __ExceptionInfo.State_Try) 
        {
            // generate leave for any preceeding catch clause 
            this.Emit(OpCodes.Leave, endLabel);
            catchEndAddr = m_length;
        }
     
        MarkLabel(endLabel);
     
     
        Label finallyEndLabel = this.DefineLabel();
        current.SetFinallyEndLabel(finallyEndLabel); 
    
        // generate leave for try clause
        this.Emit(OpCodes.Leave, finallyEndLabel); HERE'S THE ANSWER
        if (catchEndAddr == 0) 
            catchEndAddr = m_length;
        current.MarkFinallyAddr(m_length, catchEndAddr); 
    }
 
 
    
