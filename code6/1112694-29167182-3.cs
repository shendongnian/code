    namespace MyCashMachine
    {
        /* Make the machine spit money! */
        public class CashMachineService : ICashMachineService
        {
            public boolean GimmehMoniez(int howMuch)
            {
                try {
                    CashMachine.eject(howMuch); //I don't know what methods your driver exposes...
                    return true;
                } catch (CashMachineException cme) {
                    return false;
                }
            }
        }
    /* and so on */
    }
