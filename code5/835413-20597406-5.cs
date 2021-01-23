    using System;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication13
    {
        class Program
        {
            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct WAVEFORMATEX
            {
                public ushort wFormatTag;
                public ushort nChannels;
                public uint nSamplesPerSec;
                public uint nAvgBytesPerSec;
                public ushort nBlockAlign;
                public ushort wBitsPerSample;
                public ushort cbSize;
            }
    
            [DllImport(@"Win32Project1.dll", EntryPoint = "?myFun@@YGHQAXQBDI0@Z")]
            public static extern int myFun(
                IntPtr context,
                string fileName,
                uint bufferSize,
                out WAVEFORMATEX wfx
            );
    
            static void Main(string[] args)
            {
                WAVEFORMATEX wfx;
                int result = myFun((IntPtr)42, @"C:\video.wmv", 176400, out wfx);
                Console.WriteLine(result);
                Console.WriteLine(wfx.cbSize);
                Console.WriteLine(wfx.nAvgBytesPerSec);
                Console.WriteLine(wfx.nBlockAlign);
                Console.WriteLine(wfx.nChannels);
                Console.WriteLine(wfx.nSamplesPerSec);
                Console.WriteLine(wfx.wBitsPerSample);
                Console.WriteLine(wfx.wFormatTag);
    
                Console.ReadLine();
            }
        }
    }
