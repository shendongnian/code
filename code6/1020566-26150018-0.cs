	[Flags]
    public enum UsageTypes { read = 1, write = 2, wipe = 4, all = 7 }
	[Flags]
    public enum PlatformTypes { windows = 1, linux = 2, ios = 4, all = 7 }
	var e1 = License.UsageTypes.read | License.UsageTypes.write;
	var s = e1.ToString();
	Debug.Assert(s == "read, write");
	var e2 = (License.UsageTypes)Enum.Parse(typeof(License.UsageTypes), s);
	Debug.Assert(e1 == e2);
