internal Result() { }
public Result(int? code, string format, Dictionary<string, string> details = null)
{
    Code = code ?? ERROR_CODE;
    Format = format;
    if (details == null)
        Details = new Dictionary<string, string>();
    else
        Details = details;
}
