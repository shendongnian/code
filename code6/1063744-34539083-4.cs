    /// <summary>
    /// Return a buffer back to the buffer manager.
    /// </summary>
    [System.Security.SecuritySafeCritical]
    internal void Free(object buffer)
    {
      ...
      m_FreeList.Push(buffer);
    }
