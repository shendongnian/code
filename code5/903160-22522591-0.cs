    String value = "\"width: 123px ; height: 100px\" \"width: 149px ; height: 1092px\" \"width: 120px ; height: 190px\" \"width: 123px ; height: 100px\" \"width: 123px ; height: 100px\"";
			
			System.Collections.Generic.List<int> widthArray = new System.Collections.Generic.List<int>();
			System.Collections.Generic.List<int> heightArray = new System.Collections.Generic.List<int>();
			string pattern = @"([\d]+[,.]{0,1})+";
			foreach (var v in value.Split('"'))
			{
				if (!v.Trim().Equals(string.Empty)){
				widthArray.Add(Convert.ToInt32(System.Text.RegularExpressions.Regex.Match(v.Split(';')[0], pattern).Value));
				heightArray.Add(Convert.ToInt32(System.Text.RegularExpressions.Regex.Match(v.Split(';')[1], pattern).Value));
				}
			}
			int maxWidht = widthArray.Max();
			int sumHeight = heightArray.Sum();
