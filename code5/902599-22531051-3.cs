    private string GetMPTName(int ID)
            {
                try
                {
                    SGMP sgmp = DataRepository.SGMPProvider.GetByASGMPID(ID)
                    if (serviceGroupMailPresentation != null)
                    {
                        MPT mpt DataRepository.MPTProvider.GetByMPTID(SGMP.MPTID);
                        if (mailPresentationType != null)
                        {
                            return mpt.Name;
                        }
    
                    }
    
                    return string.Empty;
                }
                catch (Exception ex)
                {
                    WindowsEventLog.Write(ex);
                    throw;
                }
            }
