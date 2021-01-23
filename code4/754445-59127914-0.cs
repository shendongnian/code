csharp
using System;
using System.Runtime.CompilerServices;
using System.Threading;
public static class InterlockedEx
{
    /// <summary>
    /// Enum equivalent of <see cref="Interlocked.CompareExchange(ref Int32, Int32, Int32)"/> and <see cref="Interlocked.CompareExchange(ref Int64, Int64, Int64)"/>
    /// </summary>
    public static TEnum CompareExchange<TEnum>(ref TEnum location, TEnum value, TEnum comparand)
        where TEnum : Enum
    {
        return Unsafe.SizeOf<TEnum>() switch
        {
            // Todo: Maybe we can just use Int32 here for a byte backed enum
            // https://stackoverflow.com/a/5589515/5185376
            4 => CompareExchange32Bit(ref location, value, comparand),
            8 => CompareExchange64Bit(ref location, value, comparand),
            _ => throw new NotSupportedException("Only enums with an underlying type of 4 bytes or 8 bytes are allowed to be used with Interlocked")
        };
        static TEnum CompareExchange32Bit(ref TEnum location, TEnum value, TEnum comparand)
        {
            int comparandRaw = Unsafe.As<TEnum, int>(ref comparand);
            int valueRaw = Unsafe.As<TEnum, int>(ref value);
            ref int locationRaw = ref Unsafe.As<TEnum, int>(ref location);
            int returnRaw = Interlocked.CompareExchange(ref locationRaw, valueRaw, comparandRaw);
            return Unsafe.As<int, TEnum>(ref returnRaw);
        }
        static TEnum CompareExchange64Bit(ref TEnum location, TEnum value, TEnum comparand)
        {
            long comparandRaw = Unsafe.As<TEnum, long>(ref comparand);
            long valueRaw = Unsafe.As<TEnum, long>(ref value);
            ref long locationRaw = ref Unsafe.As<TEnum, long>(ref location);
            long returnRaw = Interlocked.CompareExchange(ref locationRaw, valueRaw, comparandRaw);
            return Unsafe.As<long, TEnum>(ref returnRaw);
        }
    }
}
