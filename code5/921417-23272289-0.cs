	public class Field
	{
		public int SegmentSequence { get; set; }
		public string SegmentId { get; set; }
		public int FieldIndex { get; set; }
		public string Value { get; set; }
		
		public static IList<Field> Parse(string hl7, string segmentDelimiter = "\r")
		{
			if(hl7 == null) throw new ArgumentNullException("hl7");
			if(hl7.Length < 4) throw new ArgumentException("Invalid HL7 syntax.");
			try
			{
				var fieldDelimiter = hl7[3];
				return hl7.Split(new string[] { segmentDelimiter }, StringSplitOptions.None)
					.Where (s => s.Length > 0)
					.SelectMany(
						(s, i) => s.Split(fieldDelimiter)
									.Select(
										(f, j) => new Field { 
														SegmentSequence = i, 
														SegmentId = s.Substring(0,3), 
														FieldIndex = i==0 ? j+1 : j, 
														Value = f
													}
											)
					).Where(o => !(o.FieldIndex == 0) && !(o.SegmentSequence==0 && o.FieldIndex==1))
					.ToList();
			}
			catch
			{
				throw new ArgumentException("Invalid HL7 syntax.");
			}
		}
		
		public static Func<Field, bool> Locate(string descriptor)
		{
			if(descriptor == null) throw new ArgumentNullException(descriptor);
			Action throwSyntaxException = () => {
				var msg = string.Format("Invalid descriptor syntax: '{0}'", descriptor);
				throw new InvalidOperationException(msg);
			};
			
			var elements = descriptor.Split(':');
			if(elements.Length != 2) throwSyntaxException();
			
			int ndx;
			if(!int.TryParse(elements[1], out ndx)) throwSyntaxException();
			
			return (field) => field.SegmentId == elements[0] && field.FieldIndex == ndx;
		}
	}
