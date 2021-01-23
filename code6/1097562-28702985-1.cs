      public class MsiInvoke
    {
        [DllImport("msi", CharSet = CharSet.Auto)]
        public static extern int MsiOpenDatabase(string filename, int persist, out IntPtr dbhandle);
        public const int MSIDBOPEN_DIRECT = 2;
        [DllImport("msi", CharSet = CharSet.Auto)]
        public static extern int MsiCloseDatabase(string filename, int persist, out IntPtr dbhandle);
        [DllImport("msi", CharSet = CharSet.Auto)]
        public static extern int MsiDatabaseCommit(IntPtr hDb);
        [DllImport("msi", CharSet = CharSet.Auto)]
        public static extern int MsiViewClose(IntPtr hView);
        [DllImport("msi", CharSet = CharSet.Auto)]
        public static extern int MsiDatabaseOpenView(IntPtr hDb, string query, out IntPtr hView);
        [DllImport("msi", CharSet = CharSet.Auto)]
        public static extern int MsiViewExecute (IntPtr hView, IntPtr hRec); 
    }
    class Program
    {
        static void Main(string[] args)
        {
            IntPtr hDb = IntPtr.Zero;
            int res = MsiInvoke.MsiOpenDatabase("setup.msi",MsiInvoke.MSIDBOPEN_DIRECT, out hDb);
            string qinsert = "UPDATE `Control` set `Control`.`Text`= 'Something' WHERE `Dialog_`='License_Dialog' AND `Control`='License'";
            IntPtr hView=IntPtr.Zero;
            res = MsiInvoke.MsiDatabaseOpenView(hDb, qinsert, out hView);
            res = MsiInvoke.MsiViewExecute(hView, IntPtr.Zero);
            res = MsiInvoke.MsiViewClose(hView);
            res = MsiInvoke.MsiDatabaseCommit(hDb);
        }
    }
