	public static class dataconversion
    {
        public static List<decimal> dataconvert()
        {
            var filedata = "";
            using (var opendialog = new OpenFileDialog())
			{
				if (opendialog.ShowDialog() == DialogResult.OK)
				{
					if (System.IO.File.Exists(opendialog.FileName))
					{
						filedata = System.IO.File.ReadAllText(opendialog.FileName);
					}
				}
			}
			return
				filedata
					.Split(' ', '\n', '\t')
					.Where(val => val != "")
					.Select(s => decimal.Parse(s))
					.ToList();
        }
    }
