    0:008> !FinalizeQueue
    *** ERROR: Symbol file could not be found.  Defaulted to export symbols for C:\Windows\Microsoft.NET\Framework64\v4.0.30319\clr.dll -
    
    ************* Symbol Loading Error Summary **************
    Module name            Error
    clr                    The system cannot find the file specified : srv*c:\symbols*http://msdl.microsoft.com/download/symbols
    
    You can troubleshoot most symbol related issues by turning on symbol loading diagnostics (!sym noisy) and repeating the command that caused symbols to be loaded.
    You should also verify that your symbol search path (.sympath) is correct.
    PDB symbol for clr.dll not loaded
    SyncBlocks to be cleaned up: 0
    Free-Threaded Interfaces to be released: 0
    MTA Interfaces to be released: 0
    STA Interfaces to be released: 0
    ----------------------------------
    generation 0 has 165 finalizable objects (0000000000a70ed0->0000000000a713f8)
    generation 1 has 0 finalizable objects (0000000000a70ed0->0000000000a70ed0)
    generation 2 has 0 finalizable objects (0000000000a70ed0->0000000000a70ed0)
    Ready for finalization 0 objects (0000000000a713f8->0000000000a713f8)
    Statistics for all finalizable objects (including all objects ready for finalization):
                  MT    Count    TotalSize Class Name
    00007ff84e389230        1           24 System.WeakReference
    00007ff84e3874a0        1           32 Microsoft.Win32.SafeHandles.SafePEFileHandle
    00007ff84e397a28        1           88 System.Diagnostics.Tracing.EventSource+OverideEventProvider
    00007ff84e36eca8        1          104 System.Runtime.Remoting.Contexts.Context
    00007ff84e397600        1          160 System.Diagnostics.Tracing.FrameworkEventSource
    00007ff84e38a5e0        6          192 Microsoft.Win32.SafeHandles.SafeWaitHandle
    00007ff84e388038        3          192 System.Threading.ReaderWriterLock
    00007ff84e384928        7          224 Microsoft.Win32.SafeHandles.SafeFileHandle
    00007ff84d4298a8        8          256 Microsoft.Win32.SafeHandles.SafeProcessHandle
    00007ff84e3822f8        4          384 System.Threading.Thread
    00007ff84e3a15a0       17          544 Microsoft.Win32.SafeHandles.SafeTokenHandle
    00007ff84e38ca60        7          728 System.IO.FileStream
    00007ff84d43c908        8         2240 System.Diagnostics.Process
    00007ff84d3f94d8      100         5600 System.Diagnostics.ProcessModule
    Total 165 objects
    0:008> .remote_exit g;
    Press Enter to exit.
