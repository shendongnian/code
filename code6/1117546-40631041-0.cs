    MessageBox((IntPtr)0, "asdasds", "My Message Box", 0);
    
                using System;
                using System.Runtime.InteropServices;
                namespace AllKeys
                {
                    public class Program
                    {
                        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
                        public static extern int MessageBox(IntPtr h, string m, string c, int type);
                        public static void Main(string[] args)
                        {
                            MessageBox((IntPtr)0, "Your Message", "My Message Box", 0);
                        }
                    }
                }
