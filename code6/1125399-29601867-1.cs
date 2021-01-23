	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			string xml = @"
    <Treatments>
        <Treatment>
            <Date>2015-04-13</Date>
            <Photos>
               <Photo>
                  <Path>...</Path>
                  <Contour>
                      <Line X1 = ""1"" Y1 = ""1"" X2 = ""155"" Y2 = ""1""/>
                      <Line X1 = ""133"" Y1 = ""1"" X2 = ""122"" Y2 = ""1""/>
                  </Contour>
               </Photo>              
             </Photos>
         </Treatment>
    </Treatments>";
			XElement xelement = XElement.Parse(xml);
			List<TreatmentData> test = xelement.Elements("Treatment")
				.Select(treatmentNode => new TreatmentData
										 {
											 Date = DateTime.ParseExact(treatmentNode.Element("Date").Value, "yyyy-MM-dd", CultureInfo.InvariantCulture),
											 Photos = treatmentNode.Element("Photos").Elements("Photo")
												.Select(photoNode => new Photo
																	{
																	   Path = photoNode.Element("Path").Value,
																	   Lines = photoNode.Element("Contour").Elements("Line")
																	   .Select(lineNode => new Line
																							{
																								X1 = int.Parse(lineNode.Attribute("X1").Value),
																								Y1 = int.Parse(lineNode.Attribute("Y1").Value),
																								X2 = int.Parse(lineNode.Attribute("X2").Value),
																								Y2 = int.Parse(lineNode.Attribute("Y2").Value),
																				}).ToArray()
														   }).ToArray()
										 }).ToList();
			Assert.AreEqual(155,test.First().Photos.First().Lines.First().X2);
		}
	}
	public class TreatmentData
	{
		public DateTime Date { get; set; }
		public IEnumerable<Photo> Photos { get; set; }
	}
	public class Photo
	{
		public string Path { get; set; }
		public IEnumerable<Line> Lines { get; set; }
	}
	public class Line
	{
		public int X1 { get; set; }
		public int Y1 { get; set; }
		public int X2 { get; set; }
		public int Y2 { get; set; }
	}
