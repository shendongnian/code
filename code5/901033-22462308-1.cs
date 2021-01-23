     	mscorlib.dll!System.Threading.CancellationToken.ThrowOperationCanceledException() Line 505 + 0x4d bytes	C#
    	mscorlib.dll!System.Threading.ManualResetEventSlim.Wait(int millisecondsTimeout, System.Threading.CancellationToken cancellationToken) Line 642	C#
    	mscorlib.dll!System.Threading.Tasks.Task.SpinThenBlockingWait(int millisecondsTimeout, System.Threading.CancellationToken cancellationToken) Line 3284 + 0xf bytes	C#
    	mscorlib.dll!System.Threading.Tasks.Task.InternalWait(int millisecondsTimeout, System.Threading.CancellationToken cancellationToken) Line 3223 + 0x10 bytes	C#
    	mscorlib.dll!System.Threading.Tasks.Task.Wait(int millisecondsTimeout, System.Threading.CancellationToken cancellationToken) Line 3129 + 0xc bytes	C#
    	mscorlib.dll!System.Threading.Tasks.Task.Wait(System.Threading.CancellationToken cancellationToken) Line 3064 + 0xe bytes	C#
    >	ConsoleApplication1.exe!ConsoleApplication1.Program.Main(string[] args) Line 82 + 0x15 bytes	C#
