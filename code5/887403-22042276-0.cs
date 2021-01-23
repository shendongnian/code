    public class Test 
    { 
        public static void Main(string[] args)
        { 
            M mm = new M(); 
            string x = mm.myFunc(1,2);     // calls M.myFunc
            int y = ((S)mm).myFunc(1,2);   // calls S.myFunc
            
            S ss = new M();
            int z = ss.myFunc(1,2);        // calls S.myFunc
        } 
    }
