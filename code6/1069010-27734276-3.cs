    PS C:\> Add-Type -TypeDefinition @'
    >>> public class SomeObject
    >>> {
    >>>     public int Id {get; set;}
    >>>     public string DisplayName {get; set;}
    >>>     // And so on..
    >>>
    >>>    public override string ToString()
    >>>    {
    >>>        return "Hello";
    >>>    }
    >>> }
    >>> '@
    
    PS C:\> $o = New-Object SomeObject
    PS C:\> [string]$o
    Hello
