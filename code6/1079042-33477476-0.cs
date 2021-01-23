	using System;
	using Spire.Xls;
	using System.Drawing;
	namespace FreezePane
	{
		class Program
		{
			static void Main(string[] args)
			{
				//Load File
				Workbook workbook = new Workbook();
				workbook.LoadFromFile
					(@"E:\Work\Documents\ExcelFiles\UserInfo.xlsx");
				Worksheet sheet = workbook.Worksheets[0];
				//Freeze Top Row
				sheet.FreezePanes(2, 1);
				//Save and Launch
				workbook.SaveToFile("FreezePane.xlsx", ExcelVersion.Version2010);
				System.Diagnostics.Process.Start(workbook.FileName);
			}
		}
	}
