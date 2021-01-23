    string keep = "Employees,Employee,EmpId,Sex,Address2,Address,Address.Zip,Address2.Country"; // I can change this format
    string[] strArr = keep.Split(',');
        foreach (var node in xDoc.Descendants().ToArray())
        {
            var path = Path(node);
            if (!strArr.Any(path.EndsWith))
            {
                node.Remove();
            }
        }
        var results = xDoc.ToString();
    }
    private static string Path(XElement x)
    {
        if (x.Parent != null)
        {
            return Path(x.Parent) + "." + x.Name;
        }
        return x.Name.ToString();
    }
