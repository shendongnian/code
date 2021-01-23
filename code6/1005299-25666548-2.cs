    static ObjectId()
        {
            __staticMachine = (GetMachineHash() + AppDomain.CurrentDomain.Id) & 0x00ffffff; // add AppDomain Id to ensure uniqueness across AppDomains
            __staticIncrement = (new Random()).Next();
            try
            {
                __staticPid = (short)GetCurrentProcessId(); // use low order two bytes only
            }
            catch (SecurityException)
            {
                __staticPid = 0;
            }
        }
