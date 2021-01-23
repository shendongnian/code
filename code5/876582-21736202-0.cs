        private void TimerProc(object state)
        {
            // check and adjust memory
            var total = MemoryManagement.SystemProgramMemory + MemoryManagement.SystemStorageMemory;
            
            var before = (MemoryManagement.SystemProgramMemory / (float)total) * 100;
            var requiredStorage = (int)(((100 - HoldProgramMemoryPercent) / 100f) * total);
            if ((requiredStorage != m_lastLevel) && (requiredStorage != MemoryManagement.SystemStorageMemory))
            {
                MemoryManagement.SystemStorageMemory = requiredStorage;
                var after = (MemoryManagement.SystemProgramMemory / (float)total) * 100;
            
                Debug.WriteLine(string.Format("Program memory changed from {0}% to {1}%", before, after));
                m_lastLevel = requiredStorage;
            }
            Debug.WriteLine(string.Format("Memory load is at {0}%", MemoryManagement.MemoryLoad));
        }
