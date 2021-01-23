    public class MyFolder
    {
        public static String Windows {get {return System.Environment.GetEnvironmentVariable("windir");}}
        public static String AppData {get {return System.Environment.GetEnvironmentVariable("appdata");}}
        public static String Temp {get {return System.Environment.GetEnvironmentVariable("temp");}}
    }
