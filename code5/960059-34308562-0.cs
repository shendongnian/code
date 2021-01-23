    /// <summary>
    /// Captures and flows the state of executing code from the generated 
    /// Python code into the IronPython runtime.
    /// </summary>    
    [DebuggerTypeProxy(typeof(CodeContext.DebugProxy)), DebuggerDisplay("module: {ModuleName}", Type="module")]
    public sealed class CodeContext { // ... }
