    public static class RoseTypeExtensions
    {
    public static string GetString(this RoseType @this)
    {
    switch (@this)
    {
    case RoseType.RedRose:
        return "Red Rose";
    case RoseType.WhiteRose:
        return "White Rose";
    case RoseType.BlackRose:
        return "Black Rose";
    default:
        throw new InvalidOperationException();
    }
    }
    }
