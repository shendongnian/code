	private string ExpandoToString(object propVal, string propName, int indent = 0)
	{
		...
		// Append this object type.
		sb.Append(Indent(indent) + UppercaseFirst(propName) + " " + propName + " consists of..." + Environment.NewLine);
		...
		sb.Append(ExpandoToString(propVal, propName, indent + 1) ...);
