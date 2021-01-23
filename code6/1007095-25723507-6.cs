		public class XmlConverter
		{
			public static Dictionary<int, Dictionary<string, Department>> Convert(XmlDocument xdoc)
			{
				Dictionary<int, Dictionary<string, Department>> result = new Dictionary<int, Dictionary<string, Department>>();
				foreach (XmlNode org in xdoc.SelectNodes("Definitions/Organization")) {
					int orgId = int.Parse(org.SelectSingleNode("@ID").Value);
					result.Add(orgId, GetDepartments(org));
				}
				return result;
			}
			private static Dictionary<string, Department> GetDepartments(XmlNode org)
			{
				Dictionary<string, Department> result = new Dictionary<string, Department>();
				foreach (XmlNode dept in org.SelectNodes("Department")) {
					string deptName = dept.SelectSingleNode("@Name").Value;
					Department d = new Department();
					d.Employees = int.Parse(dept.SelectSingleNode("Employees/text()").Value);
					d.Building = int.Parse(dept.SelectSingleNode("Building/text()").Value);
					d.Obj = dept.SelectSingleNode("Obj/text()").Value;
					result.Add(deptName, d);
				}
				return result;
			}
		}
