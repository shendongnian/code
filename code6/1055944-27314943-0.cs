	/// <summary>Splits the specified string at the specified indexes.</summary>
	/// <param name="str">The string to split.</param>
	/// <param name="delimiters">The delimiters / Indexes to split by.</param>
	/// <returns>A <see cref="T:System.string[]" /> array containing the split result.</returns>
	public static string[] Split(this string str, params int[] delimiters) {
		return delimiters.Select(
			(offset, argIndex) =>
			str.Substring(
				offset,
				(argIndex < delimiters.Length - 1
						? delimiters[argIndex + 1] - offset
						: str.Length - offset)))
					.ToArray();
	}
