    <#@ template language="C#" #>
    <#@ output extension=".generated.cs" #>
    namespace SomeNamespace
    {
    <#
    foreach(string name in new string[]{"HdlA", "HdlB", /*… and so on… */})
    {#>
        public struct <#=name#>
        {
            private IntPtr _h;
            public bool IsValid
            {
                get { return (_h != IntPtr.Zero); }
            }
            public <#=name#>(IntPtr h)
            {
                _h = h;
            }
            public void Invalidate()
            {
                _h = IntPtr.Zero;
            }
            public static implicit operator IntPtr(<#=name#> hdl)
            {
                return hdl._h;
            }
        }
    <#}#>
    }
