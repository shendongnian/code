    public class VTEST_RUN : VTEST_FSUB<int>
    {
       public VTEST_RUN()
       {
        localSMT = new VTEST_SUB();  // BAD!  localSMT isn't initialized yet!
        }
    }
