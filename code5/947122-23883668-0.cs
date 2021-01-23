    public IEnumerator<TRow> GetEnumerator()
    {
      try
      {
        yieldTransaction = StartTransaction();
        NdbScanOperation scanPub = yieldTransaction.ScanTable(m_scanRow.NdbRecordValue,           NdbOperation.LockMode.LM_Read);
        //some error checking in the middle... and than the loop
        TRow tmpRes;
        while (scanPub.nextResult<TRow>(ref m_scanRow.ManagedRow) == 0)
        {
          tmpRes = m_scanRow.GetValue();
          yield return tmpRes;
        }           
      }
      finally
      {
        yieldTransaction.Close();
      }
    }
