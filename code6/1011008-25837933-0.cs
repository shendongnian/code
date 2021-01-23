    class Program
    {
        public static System.Type objDocType;
        static void Main(string[] args)
        {
            Random rnd = new Random();
            // create the randoms beforehand as rnd.Next() isn't thread safe so we don't want to call it within the parallel.for later down the road
            var randoms = Enumerable.Range(0, 100)
                .Select(i => rnd.Next())
                .ToArray();            
            // Sequential version
            for (int yth = 1; yth < 100; yth++)
            {
                testStroboRun(randoms[yth]);
            }
            // Parallel version
            Parallel.For(1, 100, yth => 
            {
                testStroboRun(randoms[yth]);
            });
        }
        static object GetStrobo()
        {
            // Create the object here and return it, do not store it in a global variable that each thread will access, each thread needs to get his own instance, so each call should return a new instance to be used only by the calling thread
            objDocType = System.Type.GetTypeFromProgID("Stroboscope.Document");
            return System.Activator.CreateInstance(objDocType);
        }
        static void testStroboRun(int x1)
        {
            // Removed empty variable declarations, don't declare a variable before assining it, it's redundant.
            // You don't need to use a streamreader to read a text file by calling ReadToEnd, you can directly use File.ReadAllText to get your string
            //StreamReader abc = new StreamReader(@"C:\Users\Moe\Desktop\1.str");
            //String strFile = abc.ReadToEnd();
            var strFile = File.ReadAllText(@"C:\Users\Moe\Desktop\1.str");            
            strFile = Regex.Replace(strFile, "x1", "" + x1);
            // Why do you create that ConCode variable? you're just reusing strFile and doing nothing new with either strFile or ConCode later on, just pass strFile later down instead
            //string ConCode = strFile;
            var StroboApp = GetStrobo();
            objDocType.InvokeMember("ClientVersion", System.Reflection.BindingFlags.InvokeMethod, null, StroboApp, new object[] { "test Strobo" });
            int nResult = int.Parse(objDocType.InvokeMember("RunStatements", System.Reflection.BindingFlags.GetProperty, null, StroboApp, new object[] { strFile }).ToString());
            objDocType.InvokeMember("EndModel", System.Reflection.BindingFlags.InvokeMethod, null, StroboApp, null);
        }
    }
