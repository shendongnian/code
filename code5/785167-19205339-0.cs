	public partial class TestScore {
		public static TestScore Parse(String plainText) {
			var strings=plainText.Split('\t');
			var result=new TestScore();
			if(
				strings.Length<5
				||
				!double.TryParse(strings[4], out result.Score)
				||
				!DateTime.TryParse(strings[3], out result.Time)
				||
				!DateTime.TryParse(strings[2], out result.Date)
				||
				!int.TryParse(strings[1], out result.Age)
				)
				return TestScore.Error;
			result.Name=strings[0];
			return result;
		}
		public String Name;
		public int Age;
		public DateTime Date;
		public DateTime Time;
		public double Score;
		public static readonly TestScore Error=new TestScore();
	}
	public static partial class TestClass {
		public static void TestMethod() {
			var path=@"some tab splitted file";
			var lines=File.ReadAllLines(path);
			var format=""
				+"Name: {0}; Age: {1}; "
				+"Date: {2:yyyy:MM:dd}; Time {3:hh:mm}; "
				+"Score: {4}";
			var list=(
				from line in lines
				where String.Empty!=line
				let result=TestScore.Parse(line)
				where TestScore.Error!=result
				select result).ToList();
			foreach(var item in list) {
				Console.WriteLine(
					format,
					item.Name, item.Age, item.Date, item.Time, item.Score
					);
			}
		}
	}
