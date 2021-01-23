    private static MemberInfo[] GetExplicitInterfaceMembers(Type type)
    {
        HashSet<string> interfaces = new HashSet<string>(
            type.GetInterfaces().Select(i => i.FullName.Replace('+', '.')));
        List<MemberInfo> explicitInterfaceMembers = new List<MemberInfo>();
        foreach (MemberInfo member in type.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance))
        {
            int lastDot = member.Name.LastIndexOf('.');
            if (lastDot < 0)
            {
                continue;
            }
            string interfaceType = member.Name.Substring(0, lastDot);
            if (interfaces.Contains(interfaceType))
            {
                explicitInterfaceMembers.Add(member);
            }
        }
        return explicitInterfaceMembers.ToArray();
    }
