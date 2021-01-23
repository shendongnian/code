	public enum Example {
		A,
		B,
		C,
	}
	long example = CastTo<long>.From<Example>(Example.B);
