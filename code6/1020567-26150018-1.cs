	[Flags]
    public enum UsageTypes { Read = 1, Write = 2, Wipe = 4, All = 7 }
	[Flags]
    public enum PlatformTypes { Windows = 1, Linux = 2, iOs = 4, All = 7 }
	var e1 = License.UsageTypes.Read | License.UsageTypes.Write;
	var s = e1.ToString();
	Debug.Assert(s == "Read, Write");
	var e2 = (License.UsageTypes)Enum.Parse(typeof(License.UsageTypes), s);
	Debug.Assert(e1 == e2);
