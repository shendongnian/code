    public class UserInformationWriter
	{
		public string CentralFile { get; set; }
		public UserInformationWriter(string centraFile)
		{
			CentralFile = centraFile;
		}
		public void Save(UserInfomration newUserInformation)
		{
			try
			{
				var streamReader = new StreamReader(CentralFile);
				var sourceInformation = streamReader.ReadToEnd();
				streamReader.Close();
				var userCollection = (List<UserInfomration>)(sourceInformation.ToUserInfomation());
				var checkItem = ShouldModify(userCollection);
				if (checkItem.Item1)
					userCollection.Remove(checkItem.Item2);
				
				newUserInformation.DateTime = DateTime.Today;
				userCollection.Add(newUserInformation);
				File.Delete(CentralFile);
				foreach (var userInfomration in userCollection)
				{
					WriteToFile(userInfomration);
				}
			}
			catch (Exception) { }
		}
		private Tuple<bool, UserInfomration> ShouldModify(IEnumerable<UserInfomration> userInfomations)
		{
			try
			{
				foreach (var userInfomration in userInfomations)
				{
					if (userInfomration.DateTime == DateTime.Today)
					{
						return new Tuple<bool, UserInfomration>(true, userInfomration);
					}
				}
			}
			catch (Exception) { }
			return new Tuple<bool, UserInfomration>(false, null);
		}
		private void WriteToFile(UserInfomration newUserInformation)
		{
			using (var tw = new StreamWriter(CentralFile, true))
			{
				tw.WriteLine("*Total Calls: {0}", newUserInformation.Calls);
				tw.WriteLine("*Total Answered: {0}", newUserInformation.Answered);
				tw.WriteLine();
				tw.WriteLine("*Stats for Name_{0}#", newUserInformation.DateTime.ToShortDateString());
				tw.WriteLine();
			}
		}
	}
	public class UserInfomration
	{
		public DateTime DateTime { get; set; }
		public string Calls { get; set; }
		public string Answered { get; set; }
	}
	public static class StringExtension
	{
		private const string CallText = "TotalCalls:";
		private const string AnsweredText = "TotalAnswered:";
		private const string StatsForName = "StatsforName_";
		private const char ClassSeperator = '#';
		private const char ItemSeperator = '*';
		public static IEnumerable<UserInfomration> ToUserInfomation(this string input)
		{
			var splited = input.RemoveUnneededStuff().Split(ClassSeperator);
			splited = splited.Where(x => !string.IsNullOrEmpty(x)).ToArray();
			var userInformationResult = new List<UserInfomration>();
			foreach (var item in splited)
			{
				if (string.IsNullOrEmpty(item)) continue;
				var splitedInformation = item.Split(ItemSeperator);
				splitedInformation = splitedInformation.Where(x => !string.IsNullOrEmpty(x)).ToArray();
				var userInformation = new UserInfomration
				{
					Calls = splitedInformation[0].Substring(CallText.Length),
					Answered = splitedInformation[1].Substring(AnsweredText.Length),
					DateTime = ConvertStringToDateTime(splitedInformation[2])
				};
				userInformationResult.Add(userInformation);
			}
			return userInformationResult;
		}
		private static DateTime ConvertStringToDateTime(string input)
		{
			var date = input.Substring(StatsForName.Length);
			return DateTime.ParseExact(date, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
		}
		private static string RemoveUnneededStuff(this string input)
		{
			input = input.Replace("\n", String.Empty);
			input = input.Replace("\r", String.Empty);
			input = input.Replace("\t", String.Empty);
			return input.Replace(" ", string.Empty);
		}
	}
