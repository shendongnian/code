    Add-Type @'
        public class MyType3a
            {
                public string a { get; set; }
                public string b { get; set; }
            }
    
        public class MyType3
        {
            public string  c       { get; set; }
            public MyType3a subObj  { get; set; }
        }
    '@
    $obj3a = New-Object MyType3a
    $obj3a.a = 'my a'
    $obj3a.b = 'my b'
    
    $obj3 = New-Object MyType3
    $obj3.subObj = $obj3a
    PS C:\> $obj3.subObj | fl 
    a : my a
    b : my b
