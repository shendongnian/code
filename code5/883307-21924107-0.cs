    public class Scene : ICloneable
	{
		/// your codes
		public object Clone()
		{
			// it is DEEP CLONE
			using (var stream = new MemoryStream())
			{
				var formatter = new BinaryFormatter();
				formatter.Serialize(stream, this);
				stream.Position = 0;
				return (Scene)formatter.Deserialize(stream);
			}
		}
	}
