    public class LoopCounter
    {
        int test = 0;
        int variation = 0;
        int subtest = 0;
    
        const int MAX_TEST = 5;
        const int MAX_VARIATION = 4;
        const int MAX_SUBTEST = 3;
    
        public int Test {get{return test;}}
        public int Variation {get{return variation;}}
        public int Subtest {get{return subtest;}}
    
        public bool DoNext()
        {
            if (test >= MAX_TEST) // test for end all cycling
                return false;
    
            subtest++;
            if (subtest < MAX_SUBTEST)
                return true;
    
            subtest = 0;
    
            variation ++;
            if (variation < MAX_VARIATION)
                return true;
    
            variation = 0;
            
            test++;
            if (test < MAX_TEST)
                return true;
    
            return false;
        }
    }
