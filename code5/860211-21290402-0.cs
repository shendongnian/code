	public CSVSerializer Serialize<T>(T data, Func<T, object> map)
	{
		if (map == null) throw new ArgumentNullException("map");
		object mappedData = map(data);
		if (mappedData == null) throw new NullReferenceException("Mapped data produced null value");
		// Iterate over public members of `mappedData`
		MemberInfo[] members = mappedData.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Public);
		List<string> values = new List<string>();
		foreach (MemberInfo member in members)
		{
			// Skip events and methods
			if (!(member is FieldInfo || member is PropertyInfo)) continue;
			// Value of `mappedData`
			object memberVal = MemberInfoValue(member, mappedData);
			if (memberVal == null)
			{
				// If the actual value stored by `memberVal` is null, store string.Empty and continue
				values.Add(string.Empty);
				continue;
			}
			// Check if `memberVal` contains a member named "map"
			MemberInfo[] maps = memberVal.GetType().GetMember("map");
			MemberInfo memberMap = maps.Length > 0 ? maps[0] : null;
			string val = MapToString(memberVal, o => o.ToString());
			if (map != null) // map is present
			{
				// Get first property other than map
				MemberInfo dataVal = memberVal.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Public)
													.Where(mi => mi is FieldInfo || mi is PropertyInfo)
													.Except(new MemberInfo[] { memberMap })
													.DefaultIfEmpty(memberMap)
													.FirstOrDefault();
				object tmp = MemberInfoValue(memberMap, memberVal);
				if (dataVal == memberMap)
				{
					// map is only property, so serialize it
					val = MapToString(tmp, o => o.ToString());
				}
				else
				{
					// try to serialize map(dataVal), or use empty string if it fails
					Delegate dlg = tmp as Delegate;
					if (dlg != null)
					{
						object param = MemberInfoValue(dataVal, memberVal);
						try { val = MapToString(dlg, d => d.DynamicInvoke(param).ToString()); }
						catch (Exception ex)
						{
							// exception should only occur with parameter count/type mismatch
							throw new SerializationException(string.Format("Poorly formatted map function in {0}", member.Name), ex);
						}
					}
					else
					{
						// map is not a delegate (!!)
						throw new SerializationException(string.Format("map member in {0} is not a delegate type", member.Name));
					}
				}
			}
			// Handle quotes and the separator string
			val = val.Trim('"');
			if (val.Contains("\""))
			{
				val = val.Replace("\"", "\\\"");
			}
			if (val.Contains(Separator))
			{
				val = string.Format("\"{0}\"", val);
			}
			values.Add(val);
		}
		string line = string.Join(Separator, values);
		Writer.WriteLine(line);
		return this;
	}
